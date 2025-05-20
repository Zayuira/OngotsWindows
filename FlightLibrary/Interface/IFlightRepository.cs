using FlightLibrary;
using FlightLibrary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFlightRepository
{
    Task<List<Flight>> GetAllFlightsAsync();
    Task<Flight?> GetFlightByIdAsync(int id);
    Task UpdateFlightAsync(Flight flight);
}
