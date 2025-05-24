using FlightLibrary.Model;
using FlightLibrary.DTO;

/// <summary>
/// Нислэгийн үйлчилгээнүүдийн интерфэйс.
/// </summary>
public interface IFlightService
{
    /// <summary>
    /// Бүх нислэгийн дэлгэрэнгүй мэдээлэл (DTO) авах.
    /// </summary>
    /// <returns>FlightDtos жагсаалт.</returns>
    Task<List<FlightDtos>> GetAllFlightsAsync();

    /// <summary>
    /// Нислэгийн төлөвийг шинэчлэх.
    /// </summary>
    /// <param name="request">Шинэчлэх хүсэлтийн DTO.</param>
    /// <returns>Амжилттай бол true.</returns>
    Task<bool> UpdateFlightStatusAsync(UpdateFlightStatusRequest request);
}
