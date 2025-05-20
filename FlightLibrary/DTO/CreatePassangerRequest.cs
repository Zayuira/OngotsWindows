using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.DTO
{
    public class CreatePassengerRequest
    {
        public string PassportNumber { get; set; } = "";
        public string Name { get; set; } = "";
        public int FlightId { get; set; }
    }
}
