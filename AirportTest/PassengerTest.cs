using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlightLibrary;

namespace AirportTest
{
    [TestClass]
    public class PassengerTests
    {
        [TestMethod]
        public void Passenger_Constructor_SetsPropertiesCorrectly()
        {
            var seat = new Seat();
            var flight = new Flight();
            var passenger = new Passenger(1, "P123", "John Doe", 2, 3, seat, flight);

            Assert.AreEqual(1, passenger.Id);
            Assert.AreEqual("P123", passenger.PassportNumber);
            Assert.AreEqual("John Doe", passenger.Name);
            Assert.AreEqual(2, passenger.SeatId);
            Assert.AreEqual(3, passenger.FlightId);
            Assert.AreEqual(seat, passenger.Seat);
            Assert.AreEqual(flight, passenger.Flight);
        }
        [TestMethod]
        public void Passenger_DefaultConstructor_SetsDefaultValues()
        {
            var passenger1 = new Passenger();
          
        }
    }
}
