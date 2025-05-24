using System.Collections.Generic;
using System.Threading.Tasks;
using FlightLibrary.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Sqlite;

namespace AirportTest
{
    [TestClass]
    public class FlightInfoRepositoryTests
    {
        private FlightInfoRepository _repository;
        private string _testDbPath = "test.db";

        [TestInitialize]
        public void Setup()
        {
            // 1. DB үүсгэх ба хүснэгтүүдийг шинээр үүсгэх
            if (System.IO.File.Exists(_testDbPath))
                System.IO.File.Delete(_testDbPath);

            using (var conn = new SqliteConnection($"Data Source={_testDbPath}"))
            {
                conn.Open();

                // Flight хүснэгт
                var createFlight = conn.CreateCommand();
                createFlight.CommandText = @"
                    CREATE TABLE Flight (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Number TEXT NOT NULL,
                        Status INTEGER NOT NULL
                    );";
                createFlight.ExecuteNonQuery();

                // FlightInformation хүснэгт
                var createFlightInfo = conn.CreateCommand();
                createFlightInfo.CommandText = @"
                    CREATE TABLE FlightInformation (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        FlightId INTEGER NOT NULL,
                        Status TEXT NOT NULL,
                        Origin TEXT NOT NULL,
                        Destination TEXT NOT NULL,
                        DepartureTime TEXT NOT NULL,
                        ArrivalTime TEXT NOT NULL,
                        FOREIGN KEY (FlightId) REFERENCES Flight(Id)
                    );";
                createFlightInfo.ExecuteNonQuery();

                // Demo өгөгдөл оруулах
                var insertFlight = conn.CreateCommand();
                insertFlight.CommandText = @"
                    INSERT INTO Flight (Number, Status) VALUES ('MNG101', 0);
                    INSERT INTO Flight (Number, Status) VALUES ('MNG102', 1);
                ";
                insertFlight.ExecuteNonQuery();

                var insertFlightInfo = conn.CreateCommand();
                insertFlightInfo.CommandText = @"
                    INSERT INTO FlightInformation (FlightId, Status, Origin, Destination, DepartureTime, ArrivalTime)
                    VALUES (1, 'registering', 'ULN', 'HKG', '2025-06-15 09:00', '2025-06-15 13:00');
                    INSERT INTO FlightInformation (FlightId, Status, Origin, Destination, DepartureTime, ArrivalTime)
                    VALUES (2, 'boarding', 'ULN', 'NRT', '2025-06-16 10:00', '2025-06-16 14:00');
                ";
                insertFlightInfo.ExecuteNonQuery();
            }

            // 2. Repository-г тохируулах
            var inMemorySettings = new Dictionary<string, string> {
                {"ConnectionStrings:DefaultConnection", $"Data Source={_testDbPath}"}
            };
            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _repository = new FlightInfoRepository(configuration);
        }

        [TestMethod]
        public async Task GetAllAsync_ReturnsList()
        {
            var flights = await _repository.GetAllAsync();
            Assert.IsNotNull(flights);
            Assert.AreEqual(2, flights.Count);
        }

        [TestMethod]
        public async Task GetByFlightNumberAsync_ReturnsFlight_WhenExists()
        {
            var flight = await _repository.GetByFlightNumberAsync("MNG101");
            Assert.IsNotNull(flight);
            Assert.AreEqual("MNG101", flight.FlightNumber);
        }

        [TestMethod]
        public async Task UpdateFlightStatusAsync_UpdatesStatus()
        {
            var result = await _repository.UpdateFlightStatusAsync(1, "boarding");
            Assert.IsTrue(result);

            // Шинэчлэгдсэн эсэхийг шалгах
            var flight = await _repository.GetByFlightNumberAsync("MNG101");
            Assert.IsNotNull(flight);
            Assert.AreEqual("boarding", flight.Status);
        }
    }
}