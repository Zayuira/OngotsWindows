using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary
{
    public class Passenger
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; } = "";
        public string Name { get; set; } = "";
        public int? SeatId { get; set; }
        public int FlightId { get; set; }
        public Seat? Seat { get; set; }
        public Flight? Flight { get; set; }
        public Passenger(int id, string passportNumber, string name, int? seatId, int flightId, Seat? seat, Flight? flight)
        {
            Id = id;
            PassportNumber = passportNumber;
            Name = name;
            SeatId = seatId;
            FlightId = flightId;
            Seat = seat;
            Flight = flight;
        }
    }
}
