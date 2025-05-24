using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary.Model;


namespace FlightLibrary.DTO
{
    /// <summary>
    /// Нислэгийн дэлгэрэнгүй мэдээлэл хадгалах DTO.
    /// </summary>
    public class FlightDtos
    {
        /// <summary>
        /// Нислэгийн давтагдашгүй дугаар.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Нислэгийн дугаар (жишээ: MNG101).
        /// </summary>
        public string Number { get; set; } = "";
        /// <summary>
        /// Нислэгийн төлөв (string хэлбэрээр).
        /// </summary>
        public string Status { get; set; } = "";
        /// <summary>
        /// Нийт суудлын тоо.
        /// </summary>
        public int TotalSeats { get; set; }
        /// <summary>
        /// Зорчигчдод хуваарилсан суудлын тоо.
        /// </summary>
        public int AssignedSeats { get; set; }
        /// <summary>
        /// Чөлөөт (хуваарилагдаагүй) суудлын тоо.
        /// </summary>
        public int AvailableSeats => TotalSeats - AssignedSeats;
        /// <summary>
        /// Суудлын дэлгэрэнгүй мэдээллийн жагсаалт.
        /// </summary>
        public List<SeatDtos> Seats { get; set; } = new();
        /// <summary>
        /// Зорчигчдын дэлгэрэнгүй мэдээллийн жагсаалт.
        /// </summary>

        public List<PassengerDto> Passengers { get; set; } = new();

        /// <summary>
        /// Нийт зорчигчдын тоо.
        /// </summary>
        public int PassengersCount => Passengers.Count;
      
    }

}
