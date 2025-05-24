using System.Collections.Generic;
using System.Threading.Tasks;
using FlightLibrary.Model;

namespace FlightLibrary.Services
{
    /// <summary>
    /// Нислэгийн дэлгэрэнгүй мэдээллийн бизнес логикыг хэрэгжүүлэгч сервис.
    /// </summary>
    public class FlightInfoService
    {
        private readonly IFlightInfoRepository _repository;
        /// <summary>
        /// FlightInfoService конструктор нь IFlightInfoRepository интерфэйсийг авна.
        /// </summary>
        /// <param name="repository"></param>
        public FlightInfoService(IFlightInfoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Бүх нислэгийн дэлгэрэнгүй мэдээллийг асинхрон авах.
        /// </summary>
        /// <returns></returns>
        public Task<List<FlightInfo>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        /// <summary>
        /// Нислэгийн ID-аар нислэгийн дэлгэрэнгүй мэдээлэл авах.
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public Task<FlightInfo> GetByFlightIdAsync(int flightId)
        {
            return _repository.GetByFlightIdAsync(flightId);
        }

        /// <summary>
        /// Нислэгийн ID-аар нислэгийн төлөвийг шинэчлэх.
        /// </summary>
        /// <param name="flightId">Нислэгийн id</param>
        /// <param name="newStatus">Шинэчлэх төлөв</param>
        /// <returns></returns>
        public Task<bool> UpdateFlightStatusAsync(int flightId, string newStatus)
        {
            return _repository.UpdateFlightStatusAsync(flightId, newStatus);
        }
        /// <summary>
        /// Нислэгийн дугаараар нислэгийн дэлгэрэнгүй мэдээлэл авах.
        /// </summary>
        /// <param name="flightNumber">Нислэгийн дугаар</param>
        /// <returns></returns>
        public Task<FlightInfo> GetByFlightNumberAsync(string flightNumber)
        {
            return _repository.GetByFlightNumberAsync(flightNumber);
        }
    }
}