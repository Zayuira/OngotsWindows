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

    [HttpGet]
    public async Task<IActionResult> GetAllFlights()
    {
        var flights = await _flightService.GetAllFlightsAsync();
        return Ok(flights);
    }

    [HttpPost("status")]
    public async Task<IActionResult> UpdateStatus(UpdateFlightStatusRequest request)
    {
        var result = await _flightService.UpdateFlightStatusAsync(request);
        if (!result) return NotFound();
        return NoContent();
    }
}
