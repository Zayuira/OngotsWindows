using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary;

public class PassengerRepository : IPassengerRepository
{
    //private readonly AppDbContext _context;
    //public PassengerRepository(AppDbContext context)
    //{
    //    _context = context;
    //}

    //public async Task<Passenger?> GetPassengerByIdAsync(int id)
    //{
    //    return await _context.Passenger.FindAsync(id);
    //}

    //public async Task UpdatePassengerAsync(Passenger passenger)
    //{
    //    _context.Passenger.Update(passenger);
    //    await _context.SaveChangesAsync();
    //}
    private readonly AppDbContext _context;
    public PassengerRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Passenger?> GetPassengerByIdAsync(int id)
        => await _context.Passenger.FindAsync(id);

    public async Task UpdatePassengerAsync(Passenger passenger)
    {
        _context.Passenger.Update(passenger);
        await _context.SaveChangesAsync();
    }

    public async Task<Seat?> GetSeatByIdAsync(int seatId) // ШИНЭ
        => await _context.Seat.FindAsync(seatId);

    public async Task UpdateSeatAsync(Seat seat) // ШИНЭ
    {
        _context.Seat.Update(seat);
        await _context.SaveChangesAsync();
    }

}
