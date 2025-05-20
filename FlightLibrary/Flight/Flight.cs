    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary
{
    public class Flight
    {
        public static readonly List<string> Statuses = new List<string>
        {
            "Бүртгэж байна",
            "Онгоцонд сууж байна",
            "Ниссэн",
            "Хойшилсон",
            "Цуцалсан"
        };
        public int Id { get; set; }
        public string Number { get; set; } = "";
        private string _status = Statuses[0];
        public string Status
        {
            get => _status;
            set
            {
                if (Statuses.Contains(value))
                {
                    _status = value;
                }
                else
                {
                    throw new ArgumentException($"Invalid status: {value}. Allowed statuses: {string.Join(", ", Statuses)}");
                }
            }
        }
        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();
        public Flight(int id, string number, string status, ICollection<Passenger> passengers, ICollection<Seat> seats)
        {
            Id = id;
            Number = number;
            Status = status;
            Passengers = passengers;
            Seats = seats;
        }
    }
}
