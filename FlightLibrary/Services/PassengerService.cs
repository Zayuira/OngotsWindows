using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Зорчигчид суудал хуваарилах, шинэчлэх үйлчилгээ.
/// </summary>
public class PassengerService : IPassengerService
{
    private readonly IPassengerRepository _repository;
    /// <summary>
    /// Репозиторийг DI-аар авч хадгална.
    /// </summary>
    /// <param name="repository"></param>
    public PassengerService(IPassengerRepository repository)
    {
        _repository = repository;
    }
    /// <summary>
    /// Зорчигчид суудал хуваарилах (захиалах) үйлдэл хийх асинхрон функц.
    /// </summary>
    /// <param name="passengerId">Зорчигчын ID</param>
    /// <param name="seatId">Суудлын дугаар</param>
    /// <returns></returns>
    public async Task<bool> UpdatePassengerSeatAsync(int passengerId, int seatId)
    {
        var passenger = await _repository.GetPassengerByIdAsync(passengerId);
        if (passenger == null) return false;

        passenger.SeatId = seatId;

        // ШИНЭ: Seat-ийн IsAssigned-г 1 болгох
        var seat = await _repository.GetSeatByIdAsync(seatId);
        if (seat == null) return false;
        seat.IsAssigned = 1;

        await _repository.UpdatePassengerAsync(passenger);
        await _repository.UpdateSeatAsync(seat);

        return true;
    }
}