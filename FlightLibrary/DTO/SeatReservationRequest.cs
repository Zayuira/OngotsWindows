using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SeatReservationRequest
{
    public int PassengerId { get; set; }
    public int SeatId { get; set; }
    public TaskCompletionSource<bool> Tcs { get; set; }
}
