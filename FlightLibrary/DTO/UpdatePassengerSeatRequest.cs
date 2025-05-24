using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Зорчигчийн суудлын мэдээллийг шинэчлэх хүсэлтийн DTO.
/// </summary>
public class UpdatePassengerSeatRequest
{
    /// <summary>
    /// Шинэчлэх суудлын Id.
    /// </summary>
    public int SeatId { get; set; }
}