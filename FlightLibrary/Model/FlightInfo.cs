using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.Model
{
    /// <summary>
    /// нислэгийн дэлгэрэнгүй мэдээллийг илэрхийлнэ (ихэвчлэн UI-д харуулах, эсвэл API-д буцаах зориулалттай).
    /// </summary>
    public class FlightInfo
    {
        /// <summary>
        /// Нислэгийн дугаар.
        /// </summary>
        public string FlightNumber { get; set; } = string.Empty;
        /// <summary>
        /// Нислэгийн одоогийн төлөв (string хэлбэрээр).
        /// </summary>
        public string Status { get; set; } = string.Empty;
        /// <summary>
        /// Нислэг хаанаас хөдлөх.
        /// </summary>
        public string Origin { get; set; } = string.Empty;
        /// <summary>
        /// Нислэг хаашаа явах.
        /// </summary>
        public string Destination { get; set; } = string.Empty;
        /// <summary>
        /// Явах цаг (ISO string хэлбэрээр, жишээ: "2025-06-11 01:00").
        /// </summary>
        public string DepartureTime { get; set; } = string.Empty;
        /// <summary>
        /// Ирэх цаг (ISO string хэлбэрээр).
        /// </summary>
        public string ArrivalTime { get; set; } = string.Empty;

        /// <summary>
        /// DepartureTime-ийг DateTime хэлбэрээр хөрвүүлсэн (readonly).
        /// </summary>
        public DateTime DepartureDateTime => DateTime.Parse(DepartureTime);
        /// <summary>
        /// ArrivalTime-ийг DateTime хэлбэрээр хөрвүүлсэн (readonly).
        /// </summary>
        public DateTime ArrivalDateTime => DateTime.Parse(ArrivalTime);
    }

}
