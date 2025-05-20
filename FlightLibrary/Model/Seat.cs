using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary
{
    public class Seat
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public bool IsAssigned { get; set; }
        public int FlightId { get; set; }
        public Flight? Flight { get; set; }
    }
}
