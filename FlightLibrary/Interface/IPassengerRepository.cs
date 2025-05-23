using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary;

public interface IPassengerRepository
{
    Task<Passenger?> GetPassengerByIdAsync(int id);
    Task UpdatePassengerAsync(Passenger passenger);
    Task<Seat?> GetSeatByIdAsync(int seatId); 
    Task UpdateSeatAsync(Seat seat);
    Task<bool> ReserveSeatAsync(int passengerId, int seatId);
}