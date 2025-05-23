using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

public class PassengerRepository : IPassengerRepository
{
    private readonly string _connectionString;
    private readonly AppDbContext _context;
    public PassengerRepository(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _connectionString = config.GetConnectionString("DefaultConnection");
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
    public async Task<bool> ReserveSeatAsync(int passengerId, int seatId)
    {
        using var conn = new SqliteConnection(_connectionString);
        await conn.OpenAsync();
        using var tx = conn.BeginTransaction();

        var cmd = conn.CreateCommand();
        cmd.Transaction = tx;
        cmd.CommandText = @"UPDATE Seat SET IsAssigned = 1 WHERE Id = @seatId AND IsAssigned = 0";
        cmd.Parameters.AddWithValue("@seatId", seatId);

        int affected = await cmd.ExecuteNonQueryAsync();

        if (affected == 0)
        {
            await tx.RollbackAsync();
            return false;
        }

        var cmd2 = conn.CreateCommand();
        cmd2.Transaction = tx;
        cmd2.CommandText = @"UPDATE Passenger SET SeatId = @seatId WHERE Id = @passengerId";
        cmd2.Parameters.AddWithValue("@seatId", seatId);
        cmd2.Parameters.AddWithValue("@passengerId", passengerId);
        await cmd2.ExecuteNonQueryAsync();

        await tx.CommitAsync();
        return true;
    }
}
