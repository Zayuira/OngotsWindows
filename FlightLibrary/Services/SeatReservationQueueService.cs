using System.Collections.Concurrent;
using Microsoft.Extensions.DependencyInjection; // хэрэгтэй
/// <summary>
/// Суудал захиалгын хүсэлтүүдийг дараалж, аюулгүйгээр боловсруулдаг queue үйлчилгээ.
/// </summary>
public class SeatReservationQueueService
{
    private readonly ConcurrentQueue<SeatReservationRequest> _queue = new();
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    private readonly IServiceScopeFactory _scopeFactory;
    /// <summary>
    /// Суудал захиалгын хүсэлтүүдийг дараалж боловсруулдаг үйлчилгээний конструктор.
    /// </summary>
    /// <param name="scopeFactory"></param>
    public SeatReservationQueueService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        Task.Run(ProcessQueueAsync);
    }
    /// <summary>
    /// Суудал захиалгын хүсэлтүүдийг дараалж оруулах функц.
    /// </summary>
    /// <param name="passengerId">Зорчигчын ID</param>
    /// <param name="seatId">Суудлын дугаар</param>
    /// <returns></returns>
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
    /// <summary>
    /// Суудал захиалгын дарааллыг асинхрон боловсруулдаг функц.
    /// </summary>
    /// <returns></returns>
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