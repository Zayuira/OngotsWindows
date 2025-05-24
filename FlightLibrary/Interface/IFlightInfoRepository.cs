using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary.Model;
/// <summary>
/// Нислэгийн мэдээллийн репозиторийн интерфэйс.
/// </summary>
public interface IFlightInfoRepository
{
    /// <summary>
    /// Бүх нислэгийн мэдээллийг авах.
    /// </summary>
    /// <returns>FlightInfo жагсаалт.</returns>
    Task<List<FlightInfo>> GetAllAsync();

    /// <summary>
    /// Нислэгийн төлөвийг шинэчлэх.
    /// </summary>
    /// <param name="flightId">Нислэгийн ID.</param>
    /// <param name="newStatus">Шинэ төлөв (string хэлбэрээр).</param>
    /// <returns>Амжилттай бол true.</returns>
    Task<bool> UpdateFlightStatusAsync(int flightId, string newStatus);

    /// <summary>
    /// Нислэгийн ID-аар нислэгийн мэдээлэл авах.
    /// </summary>
    /// <param name="flightId">Нислэгийн ID.</param>
    /// <returns>FlightInfo объект.</returns>
    Task<FlightInfo> GetByFlightIdAsync(int flightId);

    /// <summary>
    /// Нислэгийн дугаараар нислэгийн мэдээлэл авах.
    /// </summary>
    /// <param name="flightNumber">Нислэгийн дугаар.</param>
    /// <returns>FlightInfo объект.</returns>
    Task<FlightInfo> GetByFlightNumberAsync(string flightNumber);
}