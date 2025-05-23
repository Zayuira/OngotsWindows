using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary;
using FlightLibrary.Model;

namespace AirportTest
{
    [TestClass]
    public class FlightInfoTest
    {
        [TestMethod]
        public void TestFlightInfo()
        {
            // Arrange
            var now = DateTime.Now;
            var departure = new DateTime(now.AddHours(2).Ticks - (now.AddHours(2).Ticks % TimeSpan.TicksPerSecond));
            var arrival = new DateTime(now.AddHours(5).Ticks - (now.AddHours(5).Ticks % TimeSpan.TicksPerSecond));

            var flightInfo = new FlightInfo
            {
                FlightNumber = "MNG123",
                DepartureTime = departure.ToString("yyyy-MM-dd HH:mm:ss"),
                ArrivalTime = arrival.ToString("yyyy-MM-dd HH:mm:ss"),
                Origin = "UlaanBaatar",
                Destination = "Seoul",
                Status = Flight.FlightStatusEnum.Registering.ToString(),
            };

            // Act
            var result = flightInfo.ToString();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("MNG123", flightInfo.FlightNumber);
            Assert.AreEqual(Flight.FlightStatusEnum.Registering.ToString(), flightInfo.Status);
            Assert.AreEqual(departure, flightInfo.DepartureDateTime);
            Assert.AreEqual(arrival, flightInfo.ArrivalDateTime);
        }
    }
}
