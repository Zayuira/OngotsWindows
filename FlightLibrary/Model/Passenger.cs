using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary
{
    /// <summary>
    /// нислэгийн зорчигчийн мэдээлэл.
    /// </summary>
    public class Passenger
    {
        /// <summary>
        /// Зорчигчийн давтагдашгүй дугаар.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Паспортын дугаар.
        /// </summary>
        public string PassportNumber { get; set; } = "";
        /// <summary>
        /// Зорчигчийн нэр.
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        ///  Хуваарилагдсан суудлын Id (байхгүй бол null).
        /// </summary>
        public int? SeatId { get; set; }
        /// <summary>
        ///  Аль нислэгт харьяалагдахыг заана.
        /// </summary>
        public int FlightId { get; set; }
        /// <summary>
        /// Хуваарилагдсан суудлын объект.
        /// </summary>
        public Seat? Seat { get; set; }
        /// <summary>
        /// Харьяалагдах нислэгийн объект.
        /// </summary>
        public Flight? Flight { get; set; }
        /// <summary>
        /// бүх талбаруудыг зааж өгөх эсвэл default-оор үүсгэх боломжтой.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="passportNumber"></param>
        /// <param name="name"></param>
        /// <param name="seatId"></param>
        /// <param name="flightId"></param>
        /// <param name="seat"></param>
        /// <param name="flight"></param>
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
        /// <summary>
        /// Default байгуулагч.
        /// </summary>
        public Passenger()
        {
        }
    }
}
