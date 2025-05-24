using Microsoft.EntityFrameworkCore;
using FlightLibrary.Model;
using FlightLibrary;
/// <summary>
/// Entity Framework Core ашиглан нислэгийн өгөгдлийн репозиторийг хэрэгжүүлсэн.
/// </summary>
public class FlightRepository : IFlightRepository
{
    private readonly AppDbContext _context;
    /// <summary>
    /// Db context-ийг DI-аар авна.
    /// </summary>
    public FlightRepository(AppDbContext context)
    {
        _context = context;
    }
    /// <summary>
    /// Бүх нислэгийн жагсаалт (суудал, зорчигчтой хамт) авах.
    /// </summary>
    /// <returns>нислэг төрлийн жагсаалт буцаана</returns>
    public async Task<List<Flight>> GetAllFlightsAsync()
    => await _context.Flight
        .Include(f => f.Seats)
        .Include(f => f.Passengers) // Нэмэх хэрэгтэй!
        .ToListAsync();
    /// <summary>
    /// ID-аар нислэгийн мэдээлэл (суудал, зорчигчтой хамт) авах.
    /// </summary>
    /// <param name="id">Нислэгийн ID</param>
    /// <returns>Олдслн нислэгийг буцаана</returns>
    public async Task<Flight?> GetFlightByIdAsync(int id)
        => await _context.Flight
            .Include(f => f.Seats)
            .Include(f => f.Passengers) // Нэмэх хэрэгтэй!
            .FirstOrDefaultAsync(f => f.Id == id);

    /// <summary>
    /// Нислэгийн мэдээллийг шинэчлэх (суудал, зорчигчтой хамт).
    /// </summary>
    /// <param name="flight">шинэчлэх нислэг</param>
    /// <returns></returns>
    public async Task UpdateFlightAsync(Flight flight)
    {
        _context.Flight.Update(flight);
        await _context.SaveChangesAsync();
    }
}
