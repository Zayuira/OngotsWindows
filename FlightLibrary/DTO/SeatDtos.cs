using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.DTO
{
    /// <summary>
    /// Суудлын дэлгэрэнгүй мэдээллийг илэрхийлэх DTO.
    /// </summary>
    public class SeatDtos
    {
        /// <summary>
        /// Суудлын давтагдашгүй дугаар.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Суудлын код (жишээ: A1, B3).
        /// </summary>
        public string SeatNumber { get; set; } = string.Empty;

        /// <summary>
        /// Энэ суудал хуваарилагдсан эсэх (true/false).
        /// </summary>
        public bool IsAssigned { get; set; }
    }
}
