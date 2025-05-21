using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLibrary.DTO
{
       public class PassengerDto
        {
            public int Id { get; set; }
            public string PassportNumber { get; set; } = "";
            public string Name { get; set; } = "";
            public string? SeatCode { get; set; } 
            public string FlightNumber { get; set; } = "";
            public int SeatId { get; set; }
    }

}
