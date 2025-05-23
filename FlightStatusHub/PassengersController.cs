using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/passenger")]
public class PassengerController : ControllerBase
{
    private readonly IPassengerService _passengerService;
    private readonly SeatReservationQueueService _queueService;

    public PassengerController(SeatReservationQueueService queueService)
    {
        _queueService = queueService;
    }
    public PassengerController(IPassengerService passengerService)
    {
        _passengerService = passengerService;
    }

    /// <summary>
    /// Update a passenger's seat assignment.
    /// </summary>
    /// <param name="id">Passenger ID</param>
    /// <param name="request">Seat assignment request</param>
    /// <returns>NoContent on success, NotFound if passenger or seat not found, BadRequest on invalid input</returns>
    [HttpPut("{id}/seat")]
    public async Task<IActionResult> UpdatePassengerSeat(int id, [FromBody] UpdatePassengerSeatRequest request)
    {
        if (request == null || request.SeatId <= 0)
            return BadRequest("Invalid seat data.");

        try
        {
            var success = await _passengerService.UpdatePassengerSeatAsync(id, request.SeatId);
            if (!success)
                return NotFound("Passenger or seat not found.");
            return NoContent();
        }
        catch (Exception ex)
        {
            // Лог бичих боломжтой
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
   

    [HttpPut("{id}/seat")]
    public async Task<IActionResult> ReserveSeat(int id, [FromBody] ReserveSeatRequest req)
    {
        var result = await _queueService.EnqueueReservation(id, req.SeatId);
        if (!result)
            return Conflict("Суудал аль хэдийн захиалсан байна.");
        return Ok();
    }
}
