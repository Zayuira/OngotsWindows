using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary;
using FlightLibrary.DTO;

namespace AirportTest
{
    [TestClass]
    public class FlightDTOTest
    {
        [TestMethod]
        public void TestFlightDTO()
        {
            Flight flight = new Flight();
            var flightDTO = new FlightDtos();
            flightDTO.Id = 1;
            flightDTO.Number = "MNG123";
            flightDTO.Status = Flight.FlightStatusEnum.Registering.ToString();
            flightDTO.TotalSeats = 100;
            flightDTO.AssignedSeats = 50;
            flightDTO.Seats = new List<SeatDtos>
            {
                new SeatDtos { Id = 1, SeatNumber = "1A", IsAssigned = false },
                new SeatDtos { Id = 2, SeatNumber = "1B", IsAssigned = true }
            };
            flightDTO.Passengers = new List<PassengerDto>
            {
                new PassengerDto { Id = 1, PassportNumber = "P102",Name = "John Doe", SeatCode = "1",SeatId = 2 },
                new PassengerDto { Id = 2, PassportNumber = "P103", Name = "Jane Smith", SeatCode = "1", SeatId = 1 },
                new PassengerDto { Id = 3, PassportNumber = "P104", Name = "Bob Johnson", SeatCode = null }
            };
            
            Assert.AreEqual(1, flightDTO.Id);
            Assert.AreEqual("MNG123", flightDTO.Number);
            Assert.AreEqual(Flight.FlightStatusEnum.Registering.ToString(), flightDTO.Status);
            Assert.AreEqual(100, flightDTO.TotalSeats);
            Assert.AreEqual(50, flightDTO.AssignedSeats);
            Assert.AreEqual(50, flightDTO.AvailableSeats);
            Assert.AreEqual(2, flightDTO.Seats.Count);
            Assert.AreEqual(3, flightDTO.Passengers.Count);
            Assert.AreEqual(1, flightDTO.Passengers[0].Id);
            Assert.AreEqual("John Doe", flightDTO.Passengers[0].Name);
            Assert.AreEqual(3, flightDTO.PassengersCount);


        }
    }
}
