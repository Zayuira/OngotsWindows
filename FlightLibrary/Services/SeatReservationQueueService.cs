using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection; // хэрэгтэй

public class SeatReservationQueueService
{
    private readonly ConcurrentQueue<SeatReservationRequest> _queue = new();
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    private readonly IServiceScopeFactory _scopeFactory;

    public SeatReservationQueueService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        Task.Run(ProcessQueueAsync);
    }

    public Task<bool> EnqueueReservation(int passengerId, int seatId)
    {
        var tcs = new TaskCompletionSource<bool>();
        _queue.Enqueue(new SeatReservationRequest
        {
            PassengerId = passengerId,
            SeatId = seatId,
            Tcs = tcs
        });
        return tcs.Task;
    }

    private async Task ProcessQueueAsync()
    {
        while (true)
        {
            if (_queue.TryDequeue(out var req))
            {
                await _semaphore.WaitAsync();
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var repo = scope.ServiceProvider.GetRequiredService<IPassengerRepository>();
                    var success = await repo.ReserveSeatAsync(req.PassengerId, req.SeatId);
                    req.Tcs.SetResult(success);
                }
                finally
                {
                    _semaphore.Release();
                }
            }
            else
            {
                await Task.Delay(10);
            }
        }
    }
}