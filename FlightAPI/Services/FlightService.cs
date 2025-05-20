using AutoMapper;
using FlightLibrary.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightAPI.Services
{
    public class FlightService : IFlightService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public FlightService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PassengerDto?> GetPassengerByPassportAsync(string passport)
        {
            var p = await _db.Passengers.Include(x => x.Seat)
                                        .FirstOrDefaultAsync(x => x.PassportNumber == passport);
            return p == null ? null : _mapper.Map<PassengerDto>(p);
        }

        Task<bool> IFlightService.AssignSeatAsync(string passport, string seatCode)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> AssignSeatAsync(string passport, string seatCode)
        //{
        //    var seat = await _db.Seats.FirstOrDefaultAsync(x => x.Code == seatCode);
        //    if (seat == null || seat.IsAssigned) return false;

        //    var passenger = await _db.Passengers.FirstOrDefaultAsync(x => x.PassportNumber == passport);
        //    if (passenger == null) return false;

        //    seat.IsAssigned = true;
        //    passenger.SeatId = seat.Id;
        //    await _db.SaveChangesAsync();


        //}

        //public async Task UpdateFlightStatusAsync(int flightId, string newStatus)
        //{
        //    var flight = await _db.Flights.FindAsync(flightId);
        //    if (flight != null)
        //    {
        //        flight.Status = newStatus;
        //        await _db.SaveChangesAsync();
        //        await _hub.Clients.All.SendAsync("FlightStatusUpdated", flightId, newStatus);
        //    }
        //}

        Task<PassengerDto?> IFlightService.GetPassengerByPassportAsync(string passport)
        {
            throw new NotImplementedException();
        }

        Task IFlightService.UpdateFlightStatusAsync(int flightId, string newStatus)
        {
            throw new NotImplementedException();
        }
    }


}
