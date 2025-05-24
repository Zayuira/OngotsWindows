using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using FlightLibrary;

namespace AirportTest
{
    [TestClass]
    public class AppDbContextTest
    {
        [TestMethod]
        public void CanAddAndRetrieveEntities()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDb") // Requires Microsoft.EntityFrameworkCore.InMemory
                .Options;

            using (var context = new AppDbContext(options))
            {
                var flight = new Flight { Number = "MNG123" };
                var seat = new Seat { Code = "A1", Flight = flight };
                var passenger = new Passenger { Name = "John", PassportNumber = "P123", Flight = flight, Seat = seat };

                context.Flight.Add(flight);
                context.Seat.Add(seat);
                context.Passenger.Add(passenger);
                context.SaveChanges();
            }

            using (var context = new AppDbContext(options))
            {
                Assert.AreEqual(1, context.Flight.Count());
                Assert.AreEqual(1, context.Seat.Count());
                Assert.AreEqual(1, context.Passenger.Count());

                var loadedFlight = context.Flight.First();
                var loadedSeat = context.Seat.First();
                var loadedPassenger = context.Passenger.First();

                Assert.AreEqual("MNG123", loadedFlight.Number);
                Assert.AreEqual("A1", loadedSeat.Code);
                Assert.AreEqual("John", loadedPassenger.Name);
                Assert.AreEqual("P123", loadedPassenger.PassportNumber);
            }
        }
    }
}
