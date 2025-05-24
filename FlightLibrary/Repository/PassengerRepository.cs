using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
/// <summary>
/// Зорчигчийн өгөгдлийн репозиторийн хэрэгжилт (Entity Framework ба зарим SQLite update).
/// </summary>
public class PassengerRepository : IPassengerRepository
{
    private readonly string _connectionString;
    private readonly AppDbContext _context;
    /// <summary>
    /// Конструктор нь өгөгдлийн сангийн контекст болон конфигурациас холболтын мөрийг авна.
    /// </summary>
    /// <param name="context">Context</param>
    /// <param name="config">Config</param>
    public PassengerRepository(AppDbContext context, IConfiguration config)
    {
        _context = context;
        _connectionString = config.GetConnectionString("DefaultConnection");
    }
    /// <summary>
    /// Зорчигчийн ID-аар зорчигчийн мэдээлэл авах.
    /// </summary>
    /// <param name="id">Зорчигчын ID</param>
    /// <returns>Passenger буцаана</returns>
    public async Task<Passenger?> GetPassengerByIdAsync(int id)
        => await _context.Passenger.FindAsync(id);
    /// <summary>
    /// Зорчигчийн мэдээллийг шинэчлэх.
    /// </summary>
    /// <param name="passenger">Шинэчлэх зорчигч</param>
    /// <returns></returns>
    public async Task UpdatePassengerAsync(Passenger passenger)
    {
        _context.Passenger.Update(passenger);
        await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Суудлын ID-аар суудлын мэдээлэл авах.
    /// </summary>
    /// <param name="seatId">Суудлын ID</param>
    /// <returns>Sesat буцаана</returns>
    public async Task<Seat?> GetSeatByIdAsync(int seatId) // ШИНЭ
        => await _context.Seat.FindAsync(seatId);
    /// <summary>
    /// Суудлын мэдээллийг шинэчлэх.
    /// </summary>
    /// <param name="seat">Тухайн шинэчлэх гэж буй суудал</param>
    /// <returns></returns>
    public async Task UpdateSeatAsync(Seat seat) // ШИНЭ
    {
        _context.Seat.Update(seat);
        await _context.SaveChangesAsync();
    }
    /// <summary>
    /// Зорчигчид суудал хуваарилах (захиалах).
    /// </summary>
    /// <param name="passengerId">Зорчигчын ID</param>
    /// <param name="seatId">Оноох суудлын ID</param>
    /// <returns></returns>
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
