using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/passenger")]
public class PassengerController : ControllerBase
{
    private readonly IPassengerService _passengerService;
    private readonly SeatReservationQueueService _queueService;

    public PassengerController(IPassengerService passengerService, SeatReservationQueueService queueService)
    {
        _passengerService = passengerService;
        _queueService = queueService;
    }

    /// <summary>
    /// Queue ашиглан суудал захиалах (recommended)
    /// </summary>
    [HttpPut("{id}/seat")]
    public async Task<IActionResult> ReserveSeat(int id, [FromBody] ReserveSeatRequest req)
    {
        var result = await _queueService.EnqueueReservation(id, req.SeatId);
        if (!result)
            return Conflict("Суудал аль хэдийн захиалсан байна.");
        return Ok();
    }

    /// <summary>
    /// Шууд суудал оноох (queue ашиглахгүй)
    /// </summary>
    [HttpPut("{id}/seat/direct")]
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
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}