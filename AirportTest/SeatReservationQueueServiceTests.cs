using System.Threading.Tasks;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.Extensions.DependencyInjection;
namespace AirportTest;
[TestClass]
public class SeatReservationQueueServiceTests
{
    [TestMethod]
    public async Task EnqueueReservation_ReservesSeat_AndReturnsTrue()
    {
        // Arrange
        var mockRepo = new Mock<IPassengerRepository>();
        mockRepo.Setup(r => r.ReserveSeatAsync(1, 100)).ReturnsAsync(true);

        var serviceProvider = new ServiceCollection()
            .AddSingleton(mockRepo.Object)
            .BuildServiceProvider();

        var scopeMock = new Mock<IServiceScope>();
        scopeMock.Setup(s => s.ServiceProvider).Returns(serviceProvider);

        var scopeFactoryMock = new Mock<IServiceScopeFactory>();
        scopeFactoryMock.Setup(f => f.CreateScope()).Returns(scopeMock.Object);

        var queueService = new SeatReservationQueueService(scopeFactoryMock.Object);

        // Act
        var result = await queueService.EnqueueReservation(1, 100);

        // Assert
        Assert.IsTrue(result);
        mockRepo.Verify(r => r.ReserveSeatAsync(1, 100), Times.Once);
    }

    [TestMethod]
    public async Task EnqueueReservation_ReservesSeat_AndReturnsFalse_WhenRepoFails()
    {
        // Arrange
        var mockRepo = new Mock<IPassengerRepository>();
        mockRepo.Setup(r => r.ReserveSeatAsync(2, 200)).ReturnsAsync(false);

        var serviceProvider = new ServiceCollection()
            .AddSingleton(mockRepo.Object)
            .BuildServiceProvider();

        var scopeMock = new Mock<IServiceScope>();
        scopeMock.Setup(s => s.ServiceProvider).Returns(serviceProvider);

        var scopeFactoryMock = new Mock<IServiceScopeFactory>();
        scopeFactoryMock.Setup(f => f.CreateScope()).Returns(scopeMock.Object);

        var queueService = new SeatReservationQueueService(scopeFactoryMock.Object);

        // Act
        var result = await queueService.EnqueueReservation(2, 200);

        // Assert
        Assert.IsFalse(result);
        mockRepo.Verify(r => r.ReserveSeatAsync(2, 200), Times.Once);
    }

    [TestMethod]
    public async Task EnqueueReservation_ProcessesMultipleRequests_Serially()
    {
        // Arrange
        var callOrder = new System.Collections.Generic.List<int>();
        var mockRepo = new Mock<IPassengerRepository>();
        mockRepo.Setup(r => r.ReserveSeatAsync(It.IsAny<int>(), It.IsAny<int>()))
            .Returns<int, int>((pid, sid) => {
                callOrder.Add(pid);
                return Task.FromResult(true);
            });

        var serviceProvider = new ServiceCollection()
            .AddSingleton(mockRepo.Object)
            .BuildServiceProvider();

        var scopeMock = new Mock<IServiceScope>();
        scopeMock.Setup(s => s.ServiceProvider).Returns(serviceProvider);

        var scopeFactoryMock = new Mock<IServiceScopeFactory>();
        scopeFactoryMock.Setup(f => f.CreateScope()).Returns(scopeMock.Object);

        var queueService = new SeatReservationQueueService(scopeFactoryMock.Object);

        // Act
        var t1 = queueService.EnqueueReservation(10, 201);
        var t2 = queueService.EnqueueReservation(11, 202);

        await Task.WhenAll(t1, t2);

        // Assert
        Assert.AreEqual(2, callOrder.Count);
        Assert.AreEqual(10, callOrder[0]);
        Assert.AreEqual(11, callOrder[1]);
    }
}