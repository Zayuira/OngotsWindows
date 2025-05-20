using AutoMapper;
using FlightLibrary.DTO;
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
        private readonly IHubContext<FlightHub> _hub;
        private readonly IMapper _mapper;

        public FlightService(AppDbContext db, IHubContext<FlightHub> hub, IMapper mapper)
        {
            _db = db;
            _hub = hub;
            _mapper = mapper;
        }

        public async Task<PassengerDTO?> GetPassengerByPassportAsync(string passport)
        {
            var p = await _db.Passengers.Include(x => x.Seat)
                                        .FirstOrDefaultAsync(x => x.PassportNumber == passport);
            return p == null ? null : _mapper.Map<PassengerDTO>(p);
        }

        public async Task<bool> AssignSeatAsync(string passport, string seatCode)
        {
            var seat = await _db.Seats.FirstOrDefaultAsync(x => x.Code == seatCode);
            if (seat == null || seat.IsAssigned) return false;

            var passenger = await _db.Passengers.FirstOrDefaultAsync(x => x.PassportNumber == passport);
            if (passenger == null) return false;

            seat.IsAssigned = true;
            passenger.SeatId = seat.Id;
            await _db.SaveChangesAsync();

            await _hub.Clients.All.SendAsync("SeatAssigned", passenger.PassportNumber, seatCode);
            return true;
        }

        public async Task UpdateFlightStatusAsync(int flightId, string newStatus)
        {
            var flight = await _db.Flights.FindAsync(flightId);
            if (flight != null)
            {
                flight.Status = newStatus;
                await _db.SaveChangesAsync();
                await _hub.Clients.All.SendAsync("FlightStatusUpdated", flightId, newStatus);
            }
        }
    }


}
