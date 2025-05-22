using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FlightLibrary.Model;
using Microsoft.Data.Sqlite;

public class FlightInfoRepository : IFlightInfoRepository
{
    private readonly string _connectionString;

    public FlightInfoRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
    }
    public async Task<FlightInfo> GetByPassengerIdAsync(int passengerId)
{
    using var conn = new SqliteConnection(_connectionString);
    await conn.OpenAsync();
    var cmd = conn.CreateCommand();
    cmd.CommandText = @"SELECT Flight.Number, FI.Status, FI.Origin, FI.Destination, 
                               FI.DepartureTime, FI.ArrivalTime
                        FROM FlightInformation FI
                        JOIN Flight ON FI.FlightId = Flight.Id
                        JOIN Passenger P ON P.FlightId = Flight.Id
                        WHERE P.Id = @pid";
    cmd.Parameters.AddWithValue("@pid", passengerId);

    using var reader = await cmd.ExecuteReaderAsync();
    if (await reader.ReadAsync())
    {
        return new FlightInfo
        {
            FlightNumber = reader.GetString(0),
            Status = reader.GetString(1),
            Origin = reader.GetString(2),
            Destination = reader.GetString(3),
            DepartureTime = reader.GetString(4),
            ArrivalTime = reader.GetString(5)
        };
    }
    return null;
}
    public async Task<List<FlightInfo>> GetAllAsync()
    {
        var result = new List<FlightInfo>();

        using var conn = new SqliteConnection(_connectionString);
        await conn.OpenAsync();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"SELECT Flight.Number, FI.Status, FI.Origin, FI.Destination, 
                                   FI.DepartureTime, FI.ArrivalTime
                            FROM FlightInformation FI
                            JOIN Flight ON FI.FlightId = Flight.Id";

        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            result.Add(new FlightInfo
            {
                FlightNumber = reader.GetString(0),
                Status = reader.GetString(1),
                Origin = reader.GetString(2),
                Destination = reader.GetString(3),
                DepartureTime = reader.GetString(4),
                ArrivalTime = reader.GetString(5)
            });
        }

        return result;
    }
    public async Task<bool> UpdateFlightStatusAsync(int flightId, string newStatus)
    {
        using var conn = new SqliteConnection(_connectionString);
        await conn.OpenAsync();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"UPDATE FlightInformation SET Status = @status WHERE FlightId = @id";
        cmd.Parameters.AddWithValue("@status", newStatus);
        cmd.Parameters.AddWithValue("@id", flightId);

        int affected = await cmd.ExecuteNonQueryAsync();
        return affected > 0;
    }
}