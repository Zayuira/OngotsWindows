using Microsoft.EntityFrameworkCore;
using FlightLibrary.Model;
using FlightLibrary;

public class FlightRepository : IFlightRepository
{
    private readonly AppDbContext _context;

    public FlightRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Flight>> GetAllFlightsAsync()
        => await _context.Flight.Include(f => f.Seats).ToListAsync();

    public async Task<Flight?> GetFlightByIdAsync(int id)
        => await _context.Flight.Include(f => f.Seats).FirstOrDefaultAsync(f => f.Id == id);

    public async Task UpdateFlightAsync(Flight flight)
    {
        _context.Flight.Update(flight);
        await _context.SaveChangesAsync();
    }
}
