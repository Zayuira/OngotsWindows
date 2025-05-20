using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.DTO
{
    public class SeatDtos
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; } = string.Empty;
        public bool IsAssigned { get; set; }
    }
}
