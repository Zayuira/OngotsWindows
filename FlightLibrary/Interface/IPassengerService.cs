using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Зорчигчийн үйлчилгээнүүдийн интерфэйс.
/// </summary>
public interface IPassengerService
{
    /// <summary>
    /// Зорчигчийн суудлын мэдээллийг шинэчлэх.
    /// </summary>
    /// <param name="passengerId">Зорчигчийн ID.</param>
    /// <param name="seatId">Шинэ суудлын ID.</param>
    /// <returns>Амжилттай бол true.</returns>
    Task<bool> UpdatePassengerSeatAsync(int passengerId, int seatId);
}