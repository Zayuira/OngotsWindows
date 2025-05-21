using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IPassengerService
{
    Task<bool> UpdatePassengerSeatAsync(int passengerId, int seatId);
}