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
        public int IsAssigned { get; set; } // DB-гаас int авна
        public bool IsAssignedBool => IsAssigned == 1;
        public int FlightId { get; set; }
        public Flight? Flight { get; set; }
        public Seat(int id, string code, int isAssigned, int flightId, Flight? flight)
        {
            Id = id;
            Code = code;
            IsAssigned = isAssigned;
            FlightId = flightId;
            Flight = flight;
        }
        public Seat()
        {
        }
    }
}
