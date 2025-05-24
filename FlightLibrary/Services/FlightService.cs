using FlightLibrary;
using FlightLibrary.DTO;
/// <summary>
/// Нислэгийн бизнес логикыг хэрэгжүүлэгч сервис.
/// </summary>
public class FlightService : IFlightService
{
    private readonly IFlightRepository _repository;
    /// <summary>
    /// Репозиторийг DI-аар авч хадгална.
    /// </summary>
    /// <param name="repository"></param>
    public FlightService(IFlightRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Бүх нислэгийн мэдээллийг асинхрон авах.
    /// </summary>
    /// <returns></returns>
    public async Task<List<FlightDtos>> GetAllFlightsAsync()
    {
        var flights = await _repository.GetAllFlightsAsync(); // Include Seats and Passengers!
        return flights.Select(f => new FlightDtos
        {
            Id = f.Id,
            Number = f.Number,
            Status = f.Status.ToString(),
            TotalSeats = f.Seats.Count,
            AssignedSeats = f.Seats.Count(s => (s.IsAssigned == 1)),
            
            Seats = f.Seats.Select(s => new SeatDtos
            {
                Id = s.Id,
                SeatNumber = s.Code,
                IsAssigned = (s.IsAssigned == 1) // Энэ заавал хэрэгтэй!
            }).ToList(),
            Passengers = f.Passengers.Select(p => new PassengerDto
            {
                Id = p.Id,
                Name = p.Name,
                PassportNumber = p.PassportNumber,
                SeatCode = p.Seat?.Code,
                FlightNumber = f.Number
            }).ToList()
        }).ToList();

    }
    /// <summary>
    /// Нислэгийн төлөвийг шинэчлэх асинхрон функц.
    /// </summary>
    /// <param name="request">Шинэ төлөвийн хүсэлт.</param>
    /// <returns></returns>

    public async Task<bool> UpdateFlightStatusAsync(UpdateFlightStatusRequest request)
    {
        var flight = await _repository.GetFlightByIdAsync(request.FlightId);
        if (flight == null) return false;

        if (Enum.TryParse<Flight.FlightStatusEnum>(request.NewStatus, out var parsedStatus))
        {
            flight.Status = parsedStatus;
            await _repository.UpdateFlightAsync(flight);
            return true;
        }

        return false; 
    }

}
