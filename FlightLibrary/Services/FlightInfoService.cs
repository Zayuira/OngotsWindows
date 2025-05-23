using System.Collections.Generic;
using System.Threading.Tasks;
using FlightLibrary.Model;

namespace FlightLibrary.Services
{
    public class FlightInfoService
    {
        private readonly IFlightInfoRepository _repository;

        public FlightInfoService(IFlightInfoRepository repository)
        {
            _repository = repository;
        }

        // Бүх нислэгийн мэдээлэл авах
        public Task<List<FlightInfo>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        // Id-р нислэгийн мэдээлэл авах
        public Task<FlightInfo> GetByFlightIdAsync(int flightId)
        {
            return _repository.GetByFlightIdAsync(flightId);
        }

        // Төлөв шинэчлэх
        public Task<bool> UpdateFlightStatusAsync(int flightId, string newStatus)
        {
            return _repository.UpdateFlightStatusAsync(flightId, newStatus);
        }
        public Task<FlightInfo> GetByFlightNumberAsync(string flightNumber)
        {
            return _repository.GetByFlightNumberAsync(flightNumber);
        }
    }
}