using System.Threading.Tasks;
using FlightLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace AirportTest;
[TestClass]
public class PassengerServiceTests
{
    [TestMethod]
    public async Task UpdatePassengerSeatAsync_ReturnsFalse_WhenPassengerNotFound()
    {
        // Arrange
        var mockRepo = new Mock<IPassengerRepository>();
        mockRepo.Setup(r => r.GetPassengerByIdAsync(1)).ReturnsAsync((Passenger)null);

        var service = new PassengerService(mockRepo.Object);

        // Act
        var result = await service.UpdatePassengerSeatAsync(1, 100);

        // Assert
        Assert.IsFalse(result);
        mockRepo.Verify(r => r.GetPassengerByIdAsync(1), Times.Once);
        mockRepo.Verify(r => r.UpdatePassengerAsync(It.IsAny<Passenger>()), Times.Never);
        mockRepo.Verify(r => r.UpdateSeatAsync(It.IsAny<Seat>()), Times.Never);
    }

    [TestMethod]
    public async Task UpdatePassengerSeatAsync_ReturnsFalse_WhenSeatNotFound()
    {
        // Arrange
        var mockRepo = new Mock<IPassengerRepository>();
        var passenger = new Passenger { Id = 1, Name = "Test", SeatId = 0 };
        mockRepo.Setup(r => r.GetPassengerByIdAsync(1)).ReturnsAsync(passenger);
        mockRepo.Setup(r => r.GetSeatByIdAsync(100)).ReturnsAsync((Seat)null);

        var service = new PassengerService(mockRepo.Object);

        // Act
        var result = await service.UpdatePassengerSeatAsync(1, 100);

        // Assert
        Assert.IsFalse(result);
        mockRepo.Verify(r => r.GetPassengerByIdAsync(1), Times.Once);
        mockRepo.Verify(r => r.GetSeatByIdAsync(100), Times.Once);
        mockRepo.Verify(r => r.UpdatePassengerAsync(It.IsAny<Passenger>()), Times.Never);
        mockRepo.Verify(r => r.UpdateSeatAsync(It.IsAny<Seat>()), Times.Never);
    }

    [TestMethod]
    public async Task UpdatePassengerSeatAsync_UpdatesPassengerAndSeat_WhenBothExist()
    {
        // Arrange
        var mockRepo = new Mock<IPassengerRepository>();
        var passenger = new Passenger { Id = 1, Name = "Test", SeatId = 0 };
        var seat = new Seat { Id = 100, Code = "A1", IsAssigned = 0 };

        mockRepo.Setup(r => r.GetPassengerByIdAsync(1)).ReturnsAsync(passenger);
        mockRepo.Setup(r => r.GetSeatByIdAsync(100)).ReturnsAsync(seat);

        var service = new PassengerService(mockRepo.Object);

        // Act
        var result = await service.UpdatePassengerSeatAsync(1, 100);

        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(100, passenger.SeatId);
        Assert.AreEqual(1, seat.IsAssigned);

        mockRepo.Verify(r => r.UpdatePassengerAsync(passenger), Times.Once);
        mockRepo.Verify(r => r.UpdateSeatAsync(seat), Times.Once);
    }
}