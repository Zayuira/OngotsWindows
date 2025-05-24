using System;
using System.Collections.Generic;

namespace FlightLibrary
{
    /// <summary>
    /// Тухайн нэг нислэгийн үндсэн мэдээллийг хадгалдаг класс юм.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// дэд enum нь нислэгийн төлөвийг илэрхийлнэ:
        /// </summary>
        public enum FlightStatusEnum
        {
            Registering,    // Бүртгэж байна
            Boarding,       // Онгоцонд сууж байна
            Departed,       // Ниссэн
            Delayed,        // Хойшилсон
            Cancelled       // Цуцалсан
        }
        /// <summary>
        /// Нислэгийн давтагдашгүй дугаар.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Нислэгийн дугаар (жишээ: MNG101)
        /// </summary>
        public string Number { get; set; } = "";
        /// <summary>
        /// Нислэгийн одоогийн төлөв (enum).
        /// </summary>
        public FlightStatusEnum Status { get; set; } = FlightStatusEnum.Registering;
        /// <summary>
        /// Энэ нислэгтэй холбоотой зорчигчдын жагсаалт.
        /// </summary>
        public ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
        /// <summary>
        /// Энэ нислэг дээрх суудлуудын жагсаалт.
        /// </summary>
        public ICollection<Seat> Seats { get; set; } = new List<Seat>();

        /// <summary>
        ///  бүх талбаруудыг зааж өгөх эсвэл default-оор үүсгэх боломжтой.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="number"></param>
        /// <param name="status"></param>
        /// <param name="passengers"></param>
        /// <param name="seats"></param>
        public Flight(int id, string number, FlightStatusEnum status, ICollection<Passenger> passengers, ICollection<Seat> seats)
        {
            Id = id;
            Number = number;
            Status = status;
            Passengers = passengers ?? new List<Passenger>();
            Seats = seats ?? new List<Seat>();
        }
        /// <summary>
        /// Default байгуулагч.
        /// </summary>
        public Flight()
        {
        }
    }
}
