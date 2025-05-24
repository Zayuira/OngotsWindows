using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.DTO
{
    /// <summary>
    /// Нислэгийн төлөв шинэчлэх хүсэлтийн DTO.
    /// </summary>
    public class UpdateFlightStatusRequest
    {
        /// <summary>
        /// Шинэчлэх нислэгийн Id.
        /// </summary>
        public int FlightId { get; set; }

        /// <summary>
        /// Тавих шинэ төлөв (string хэлбэрээр).
        /// </summary>
        public string NewStatus { get; set; } = "";
    }
}

