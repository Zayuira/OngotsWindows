using Microsoft.AspNetCore.Mvc;
using FlightLibrary.DTO;

[ApiController]
[Route("api/[controller]")]
public class FlightsController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightsController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    /// <summary>
    /// Бүх нислэгийн мэдээлэл авах
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FlightDtos>>> GetAllFlights()
    {
        var flights = await _flightService.GetAllFlightsAsync();
        return Ok(flights);
    }

    /// <summary>
    /// Нислэгийн төлөв шинэчлэх
    /// </summary>
    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateFlightStatusRequest request)
    {
        if (id != request.FlightId)
            return BadRequest("URL болон request дахь нислэгийн ID зөрүүтэй байна.");

        var updated = await _flightService.UpdateFlightStatusAsync(request);
        if (!updated)
            return NotFound($"Нислэг олдсонгүй: {id}");

        return NoContent();
    }

    // Нэмэлтээр нэг нислэг авах endpoint (хэрэгцээтэй бол)
    [HttpGet("{id}")]
    public async Task<ActionResult<FlightDtos>> GetFlight(int id)
    {
        var flights = await _flightService.GetAllFlightsAsync();
        var flight = flights.FirstOrDefault(f => f.Id == id);
        if (flight == null)
            return NotFound();
        return Ok(flight);
    }
}