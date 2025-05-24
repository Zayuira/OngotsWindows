using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary;

/// <summary>
/// Зорчигчийн өгөгдлийн репозиторийн интерфэйс.
/// </summary>
public interface IPassengerRepository
{
    /// <summary>
    /// Зорчигчийн ID-аар зорчигчийн мэдээлэл авах.
    /// </summary>
    /// <param name="id">Зорчигчийн ID.</param>
    /// <returns>Passenger объект эсвэл null.</returns>
    Task<Passenger?> GetPassengerByIdAsync(int id);

    /// <summary>
    /// Зорчигчийн мэдээллийг шинэчлэх.
    /// </summary>
    /// <param name="passenger">Шинэчлэгдэх зорчигчийн объект.</param>
    Task UpdatePassengerAsync(Passenger passenger);

    /// <summary>
    /// Суудлын ID-аар суудлын мэдээлэл авах.
    /// </summary>
    /// <param name="seatId">Суудлын ID.</param>
    /// <returns>Seat объект эсвэл null.</returns>
    Task<Seat?> GetSeatByIdAsync(int seatId);

    /// <summary>
    /// Суудлын мэдээллийг шинэчлэх.
    /// </summary>
    /// <param name="seat">Шинэчлэгдэх суудлын объект.</param>
    Task UpdateSeatAsync(Seat seat);

    /// <summary>
    /// Зорчигчид суудал хуваарилах (захиалах).
    /// </summary>
    /// <param name="passengerId">Зорчигчийн ID.</param>
    /// <param name="seatId">Суудлын ID.</param>
    /// <returns>Амжилттай бол true.</returns>
    Task<bool> ReserveSeatAsync(int passengerId, int seatId);
}