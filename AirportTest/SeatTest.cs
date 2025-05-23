using FlightLibrary;

namespace AirportTest
{
    [TestClass]
    public class SeatTests
    {
        [TestMethod]
        public void Seat_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            var flight = new Flight();
            int id = 1;
            string code = "A1";
            int isAssigned = 1;
            int flightId = 10;

            // Act
            var seat = new Seat(id, code, isAssigned, flightId, flight);

            // Assert
            Assert.AreEqual(id, seat.Id);
            Assert.AreEqual(code, seat.Code);
            Assert.AreEqual(isAssigned, seat.IsAssigned);
            Assert.AreEqual(flightId, seat.FlightId);
            Assert.AreEqual(flight, seat.Flight);
            Assert.IsTrue(seat.IsAssignedBool);
        }

        [TestMethod]
        public void Seat_IsAssignedBool_ReturnsFalse_WhenIsAssignedIsZero()
        {
            var seat = new Seat(1, "B2", 0, 20, null);
            Assert.IsFalse(seat.IsAssignedBool);
        }

        [TestMethod]
        public void Seat_DefaultConstructor_InitializesDefaults()
        {
            var seat = new Seat();
            Assert.AreEqual(0, seat.Id);
            Assert.AreEqual("", seat.Code);
            Assert.AreEqual(0, seat.IsAssigned);
            Assert.AreEqual(0, seat.FlightId);
            Assert.IsNull(seat.Flight);
            Assert.IsFalse(seat.IsAssignedBool);
        }
    }
}
