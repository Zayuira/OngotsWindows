using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary.DTO;

namespace FlightAPI.Services
{
    public interface IFlightService
    {
        Task<PassengerDto?> GetPassengerByPassportAsync(string passport);
        Task<bool> AssignSeatAsync(string passport, string seatCode);
        Task UpdateFlightStatusAsync(int flightId, string newStatus);
    }
}
