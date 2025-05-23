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

        // 1. FlightInformation хүснэгтийн Status-ийг шинэчлэнэ
        var cmd1 = conn.CreateCommand();
        cmd1.CommandText = @"UPDATE FlightInformation SET Status = @status WHERE FlightId = @id";
        cmd1.Parameters.AddWithValue("@status", newStatus);
        cmd1.Parameters.AddWithValue("@id", flightId);
        int affected1 = await cmd1.ExecuteNonQueryAsync();

        // 2. FlightStatusEnum индексийг ол (enum-ыг string-ээс int рүү хөрвүүлнэ)
        int statusIndex = GetFlightStatusEnumIndex(newStatus);

        // 3. Flight хүснэгтийн Status баганын утгыг шинэчил
        var cmd2 = conn.CreateCommand();
        cmd2.CommandText = @"UPDATE Flight SET Status = @statusIndex WHERE Id = @id";
        cmd2.Parameters.AddWithValue("@statusIndex", statusIndex);
        cmd2.Parameters.AddWithValue("@id", flightId);
        int affected2 = await cmd2.ExecuteNonQueryAsync();

        return affected1 > 0 && affected2 > 0;
    }
    public async Task<FlightInfo> GetByFlightIdAsync(int flightId)
    {
        using var conn = new SqliteConnection(_connectionString);
        await conn.OpenAsync();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"SELECT Flight.Number, FI.Status, FI.Origin, FI.Destination, 
                               FI.DepartureTime, FI.ArrivalTime
                        FROM FlightInformation FI
                        JOIN Flight ON FI.FlightId = Flight.Id
                        WHERE FI.FlightId = @fid";
        cmd.Parameters.AddWithValue("@fid", flightId);

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
    public async Task<FlightInfo> GetByFlightNumberAsync(string flightNumber)
    {
        using var conn = new SqliteConnection(_connectionString);
        await conn.OpenAsync();
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"SELECT Flight.Number, FI.Status, FI.Origin, FI.Destination, 
                               FI.DepartureTime, FI.ArrivalTime
                        FROM FlightInformation FI
                        JOIN Flight ON FI.FlightId = Flight.Id
                        WHERE Flight.Number = @fnumber";
        cmd.Parameters.AddWithValue("@fnumber", flightNumber);

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
    private int GetFlightStatusEnumIndex(string status)
    {
        return status.ToLower() switch
        {
            "registering" or "бүртгэж байна" => 0,
            "boarding" or "онгоцонд сууж байна" => 1,
            "departed" or "ниссэн" => 2,
            "delayed" or "хойшилсон" => 3,
            "cancelled" or "цуцалсан" => 4,
            _ => 0
        };
    }
}