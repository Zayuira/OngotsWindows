using System.Collections.Generic;
using System.Threading.Tasks;
using FlightLibrary.Model;
using FlightLibrary.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AirportTest
{
    [TestClass]
    public class FlightInfoServiceTests
    {
        [TestMethod]
        public async Task GetAllAsync_ReturnsAllFlights()
        {
            // Arrange
            var mockRepo = new Mock<IFlightInfoRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<FlightInfo>
                {
                    new FlightInfo { FlightNumber = "MNG101", Status = "registering" },
                    new FlightInfo { FlightNumber = "MNG102", Status = "boarding" }
                });

            var service = new FlightInfoService(mockRepo.Object);

            // Act
            var flights = await service.GetAllAsync();

            // Assert
            Assert.IsNotNull(flights);
            Assert.AreEqual(2, flights.Count);
            Assert.IsTrue(flights.Exists(f => f.FlightNumber == "MNG101"));
        }

        [TestMethod]
        public async Task GetByFlightIdAsync_ReturnsFlight_WhenFound()
        {
            // Arrange
            var mockRepo = new Mock<IFlightInfoRepository>();
            mockRepo.Setup(repo => repo.GetByFlightIdAsync(1))
                .ReturnsAsync(new FlightInfo { FlightNumber = "MNG101", Status = "registering" });

            var service = new FlightInfoService(mockRepo.Object);

            // Act
            var flight = await service.GetByFlightIdAsync(1);

            // Assert
            Assert.IsNotNull(flight);
            Assert.AreEqual("MNG101", flight.FlightNumber);
        }

        [TestMethod]
        public async Task UpdateFlightStatusAsync_CallsRepository()
        {
            // Arrange
            var mockRepo = new Mock<IFlightInfoRepository>();
            mockRepo.Setup(repo => repo.UpdateFlightStatusAsync(1, "boarding"))
                .ReturnsAsync(true);

            var service = new FlightInfoService(mockRepo.Object);

            // Act
            var result = await service.UpdateFlightStatusAsync(1, "boarding");

            // Assert
            Assert.IsTrue(result);
            mockRepo.Verify(r => r.UpdateFlightStatusAsync(1, "boarding"), Times.Once());
        }
        [TestMethod]
        public async Task GetByFlightNumberAsync_ReturnsFlight_WhenFound()
        {
            // Arrange
            var mockRepo = new Mock<IFlightInfoRepository>();
            var expected = new FlightInfo { FlightNumber = "MNG101", Status = "registering" };
            mockRepo.Setup(r => r.GetByFlightNumberAsync("MNG101"))
                .ReturnsAsync(expected);

            var service = new FlightInfoService(mockRepo.Object);

            // Act
            var result = await service.GetByFlightNumberAsync("MNG101");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.FlightNumber, result.FlightNumber);
            Assert.AreEqual(expected.Status, result.Status);
        }

        [TestMethod]
        public async Task GetByFlightNumberAsync_ReturnsNull_WhenNotFound()
        {
            // Arrange
            var mockRepo = new Mock<IFlightInfoRepository>();
            mockRepo.Setup(r => r.GetByFlightNumberAsync("NOT_FOUND"))
                .ReturnsAsync((FlightInfo)null);

            var service = new FlightInfoService(mockRepo.Object);

            // Act
            var result = await service.GetByFlightNumberAsync("NOT_FOUND");

            // Assert
            Assert.IsNull(result);
        }
    }
}