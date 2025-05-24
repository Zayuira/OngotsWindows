using FlightLibrary;
using FlightLibrary.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// Нислэгийн өгөгдлийн репозиторийн интерфэйс.
/// </summary>
public interface IFlightRepository
{
    /// <summary>
    /// Бүх нислэгийн жагсаалт авах.
    /// </summary>
    /// <returns>Flight жагсаалт.</returns>
    Task<List<Flight>> GetAllFlightsAsync();

    /// <summary>
    /// ID-аар нислэгийн мэдээлэл авах.
    /// </summary>
    /// <param name="id">Нислэгийн ID.</param>
    /// <returns>Flight объект эсвэл null.</returns>
    Task<Flight?> GetFlightByIdAsync(int id);

    /// <summary>
    /// Нислэгийн мэдээллийг шинэчлэх.
    /// </summary>
    /// <param name="flight">Шинэчлэгдэх нислэгийн объект.</param>
    Task UpdateFlightAsync(Flight flight);
}
