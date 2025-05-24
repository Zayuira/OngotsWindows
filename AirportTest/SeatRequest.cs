using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary.DTO;
namespace AirportTest
{
    [TestClass]
    public class SeatRequest
    {
        [TestMethod]
        public void TestSeatRequest()
        {
            var seatRequest = new ReserveSeatRequest();
            seatRequest.SeatId = 1;
            Assert.AreEqual(1, seatRequest.SeatId);
        }
        [TestMethod]
        public void TestSeatRequest2()
        {
            var seatRequest = new SeatReservationRequest();
            seatRequest.PassengerId = 1;
            seatRequest.SeatId = 2;
            seatRequest.Tcs = new TaskCompletionSource<bool>();

            Assert.IsNotNull(seatRequest.Tcs); // Check Tcs is assigned
            Assert.IsInstanceOfType(seatRequest.Tcs, typeof(TaskCompletionSource<bool>)); // Check type
            Assert.AreEqual(1, seatRequest.PassengerId);
            Assert.AreEqual(2, seatRequest.SeatId);
        }
        [TestMethod]
        public void UpdatePassengerSeatRequestTest()
        {
            var updatePassengerSeatRequest = new UpdatePassengerSeatRequest();
            updatePassengerSeatRequest.SeatId = 1;
            Assert.AreEqual(1, updatePassengerSeatRequest.SeatId);
        }
        [TestMethod]
        public void UpdateFlightStatusRequest()
        {
            var updateFlightStatusRequest = new UpdateFlightStatusRequest();
            updateFlightStatusRequest.FlightId = 1;
            updateFlightStatusRequest.NewStatus = "OnTime";
            Assert.AreEqual(1, updateFlightStatusRequest.FlightId);
            Assert.AreEqual("OnTime", updateFlightStatusRequest.NewStatus);
        }
    }
}
