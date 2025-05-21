using System;
using System.Collections.Generic;

namespace FlightLibrary
{
    public class Flight
    {
        public enum FlightStatusEnum
        {
            Registering,    // Бүртгэж байна
            Boarding,       // Онгоцонд сууж байна
            Departed,       // Ниссэн
            Delayed,        // Хойшилсон
            Cancelled       // Цуцалсан
        }

        public int Id { get; set; }
        public string Number { get; set; } = "";

        public FlightStatusEnum Status { get; set; } = FlightStatusEnum.Registering;

        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();

        // Constructor with all fields
        public Flight(int id, string number, FlightStatusEnum status, ICollection<Passenger> passengers, ICollection<Seat> seats)
        {
            Id = id;
            Number = number;
            Status = status;
            Passengers = passengers ?? new List<Passenger>();
            Seats = seats ?? new List<Seat>();
        }

        public Flight()
        {
        }
    }
}
