using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PassengerService : IPassengerService
{
    //private readonly IPassengerRepository _repository;

    //public PassengerService(IPassengerRepository repository)
    //{
    //    _repository = repository;
    //}

    //public async Task<bool> UpdatePassengerSeatAsync(int passengerId, int seatId)
    //{
    //    var passenger = await _repository.GetPassengerByIdAsync(passengerId);
    //    if (passenger == null) return false;

    //    passenger.SeatId = seatId;
    //    await _repository.UpdatePassengerAsync(passenger);
    //    return true;
    //}

    private readonly IPassengerRepository _repository;

    public PassengerService(IPassengerRepository repository)
    {
        _repository = repository;
    }

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