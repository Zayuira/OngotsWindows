using FlightLibrary.Model;
using FlightLibrary.DTO;

public interface IFlightService
{
    Task<List<FlightDtos>> GetAllFlightsAsync();
    Task<bool> UpdateFlightStatusAsync(UpdateFlightStatusRequest request);
}
