using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightLibrary;
using FlightLibrary.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace AirportTest;
[TestClass]
public class FlightServiceTests
{
    [TestMethod]
    public async Task GetAllFlightsAsync_ReturnsFlightDtosList()
    {
        // Arrange
        var flights = new List<Flight>
        {
            new Flight
            {
                Id = 1,
                Number = "MNG101",
                Status = Flight.FlightStatusEnum.Registering,
                Seats = new List<Seat>
                {
                    new Seat { Id = 1, Code = "A1", IsAssigned = 1 },
                    new Seat { Id = 2, Code = "A2", IsAssigned = 0 }
                },
                Passengers = new List<Passenger>
                {
                    new Passenger { Id = 10, Name = "Bat", PassportNumber = "A123", Seat = new Seat { Code = "A1" } }
                }
            }
        };

        var mockRepo = new Mock<IFlightRepository>();
        mockRepo.Setup(r => r.GetAllFlightsAsync()).ReturnsAsync(flights);

        var service = new FlightService(mockRepo.Object);

        // Act
        var result = await service.GetAllFlightsAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
        Assert.AreEqual("MNG101", result[0].Number);
        Assert.AreEqual(2, result[0].TotalSeats);
        Assert.AreEqual(1, result[0].AssignedSeats);
        Assert.AreEqual(2, result[0].Seats.Count);
        Assert.AreEqual(1, result[0].Passengers.Count);
        Assert.AreEqual("Bat", result[0].Passengers[0].Name);
        Assert.AreEqual("A1", result[0].Passengers[0].SeatCode);
    }

    [TestMethod]
    public async Task UpdateFlightStatusAsync_ReturnsFalse_WhenFlightNotFound()
    {
        // Arrange
        var mockRepo = new Mock<IFlightRepository>();
        mockRepo.Setup(r => r.GetFlightByIdAsync(1)).ReturnsAsync((Flight)null);

        var service = new FlightService(mockRepo.Object);

        // Act
        var result = await service.UpdateFlightStatusAsync(new UpdateFlightStatusRequest { FlightId = 1, NewStatus = "Registering" });

        // Assert
        Assert.IsFalse(result);
        mockRepo.Verify(r => r.UpdateFlightAsync(It.IsAny<Flight>()), Times.Never);
    }

    [TestMethod]
    public async Task UpdateFlightStatusAsync_ReturnsFalse_WhenStatusIsInvalid()
    {
        // Arrange
        var mockRepo = new Mock<IFlightRepository>();
        var flight = new Flight { Id = 1, Status = Flight.FlightStatusEnum.Registering };
        mockRepo.Setup(r => r.GetFlightByIdAsync(1)).ReturnsAsync(flight);

        var service = new FlightService(mockRepo.Object);

        // Act
        var result = await service.UpdateFlightStatusAsync(new UpdateFlightStatusRequest { FlightId = 1, NewStatus = "INVALID_ENUM" });

        // Assert
        Assert.IsFalse(result);
        mockRepo.Verify(r => r.UpdateFlightAsync(It.IsAny<Flight>()), Times.Never);
    }

    [TestMethod]
    public async Task UpdateFlightStatusAsync_ReturnsTrue_WhenStatusIsValid()
    {
        // Arrange
        var mockRepo = new Mock<IFlightRepository>();
        var flight = new Flight { Id = 1, Status = Flight.FlightStatusEnum.Registering };
        mockRepo.Setup(r => r.GetFlightByIdAsync(1)).ReturnsAsync(flight);

        var service = new FlightService(mockRepo.Object);

        // Act
        var result = await service.UpdateFlightStatusAsync(new UpdateFlightStatusRequest { FlightId = 1, NewStatus = "Boarding" });

        // Assert
        Assert.IsTrue(result);
        mockRepo.Verify(r => r.UpdateFlightAsync(flight), Times.Once);
        Assert.AreEqual(Flight.FlightStatusEnum.Boarding, flight.Status);
    }
}