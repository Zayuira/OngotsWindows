using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.DTO
{
    public class UpdateFlightStatusRequest
    {
        public int FlightId { get; set; }
        public string NewStatus { get; set; } = "";
    }
}

