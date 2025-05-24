using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.DTO
{
    /// <summary>
    /// Зорчигчийн дэлгэрэнгүй мэдээллийг илэрхийлэх DTO.
    /// </summary>
    public class PassengerDto
    {
        /// <summary>
        /// Зорчигчийн давтагдашгүй дугаар.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Зорчигчийн паспортын дугаар.
        /// </summary>
        public string PassportNumber { get; set; } = "";

        /// <summary>
        /// Зорчигчийн нэр.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Зорчигчид хуваарилсан суудлын код. (байхгүй бол null)
        /// </summary>
        public string? SeatCode { get; set; }

        /// <summary>
        /// Зорчигчийн нислэгийн дугаар.
        /// </summary>
        public string FlightNumber { get; set; } = "";

        /// <summary>
        /// Зорчигчид хуваарилсан суудлын Id.
        /// </summary>
        public int SeatId { get; set; }
    }

}
