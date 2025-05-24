using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Суудал захиалгын эгнээнд оруулах хүсэлт (queue-д зориулсан).
/// </summary>
public class SeatReservationRequest
{
    /// <summary>
    /// Захиалга хийж буй зорчигчийн Id.
    /// </summary>
    public int PassengerId { get; set; }

    /// <summary>
    /// Захиалах суудлын Id.
    /// </summary>
    public int SeatId { get; set; }

    /// <summary>
    /// Захиалгын үр дүнг буцаах TaskCompletionSource.
    /// </summary>
    public TaskCompletionSource<bool> Tcs { get; set; }
}
