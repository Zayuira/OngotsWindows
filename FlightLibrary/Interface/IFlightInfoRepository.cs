using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary.Model;
public interface IFlightInfoRepository
{
    Task<List<FlightInfo>> GetAllAsync();
    Task<bool> UpdateFlightStatusAsync(int flightId, string newStatus);
}