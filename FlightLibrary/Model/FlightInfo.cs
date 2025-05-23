using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.Model
{
    public class FlightInfo
    {

        public string FlightNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string DepartureTime { get; set; } = string.Empty; // ISO string "2025-06-11 01:00"
        public string ArrivalTime { get; set; } = string.Empty;

        // Optional: DateTime хувилбарыг буцаах readonly property
        public DateTime DepartureDateTime => DateTime.Parse(DepartureTime);
        public DateTime ArrivalDateTime => DateTime.Parse(ArrivalTime);
    }

}
