using FlightLibrary;

namespace AirportTest
{
    [TestClass]
    public sealed class FlightTest
    {
        [TestMethod]
        public void FlightCreate()
        {
            List<Passenger> passengers = new List<Passenger>();
            List<Seat> seats = new List<Seat>();
            Flight flight = new Flight(1, "MNG101", 0, passengers, seats);
            Assert.AreEqual(1, flight.Id);
        }
        [TestMethod]
        public void FlightCreateNullPassengerAndSeat()
        {
            Flight flight = new Flight(1, "MNG101", 0, null, null);
            Assert.AreEqual(1, flight.Id);
        }
    }
}
