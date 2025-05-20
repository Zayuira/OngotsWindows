using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.DTO
{
    public class AssignSeatRequest
    {
        public int PassengerId { get; set; }
        public int SeatId { get; set; }
    }
}
