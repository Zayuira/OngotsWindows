using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary
{
    /// <summary>
    /// нислэгийн нэг суудлыг илэрхийлнэ.
    /// </summary>
    public class Seat
    {
        /// <summary>
        /// Суудлын ID.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Суудлын дугаар (жишээ: A1, B3 гэх мэт).
        /// </summary>
        public string Code { get; set; } = "";
        /// <summary>
        /// Энэ суудалд зорчигч хуваарилагдсан эсэх (1 бол хуваарилагдсан, 0 бол хоосон).
        /// </summary>
        public int IsAssigned { get; set; } // DB-гаас int авна
        /// <summary>
        /// bool хэлбэрт хөрвүүлсэн төлөв (true/false).
        /// </summary>
        public bool IsAssignedBool => IsAssigned == 1;
        /// <summary>
        /// Аль нислэгт харьяалагдахыг заана.
        /// </summary>
        public int FlightId { get; set; }
        /// <summary>
        /// Харьяалагдах нислэгийн объект.
        /// </summary>
        public Flight? Flight { get; set; }
        /// <summary>
        ///  бүх талбаруудыг зааж өгөх эсвэл default-оор үүсгэх боломжтой.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <param name="isAssigned"></param>
        /// <param name="flightId"></param>
        /// <param name="flight"></param>
        public Seat(int id, string code, int isAssigned, int flightId, Flight? flight)
        {
            Id = id;
            Code = code;
            IsAssigned = isAssigned;
            FlightId = flightId;
            Flight = flight;
        }
        /// <summary>
        /// Default Байгуулагч.
        /// </summary>
        public Seat()
        {
        }
    }
}
