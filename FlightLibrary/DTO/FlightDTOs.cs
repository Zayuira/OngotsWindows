using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.DTO
{
    public class FlightDtos
    {
        public int Id { get; set; }
        public string Number { get; set; } = "";
        public string Status { get; set; } = "";
        public int TotalSeats { get; set; }
        public int AssignedSeats { get; set; }
        public int AvailableSeats => TotalSeats - AssignedSeats;
    }
}
