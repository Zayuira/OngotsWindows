using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary.DTO;
using FlightLibrary.Model;
using FlightLibrary.Services;




// FlightAPI/Controllers/FlightInfoController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class FlightInfoController : ControllerBase
{
    private readonly FlightInfoService _service;
    private readonly IFlightInfoRepository _repository;
    private readonly IHubContext<FlightStatusHub.FlightStatusHub> _hubContext;

    public FlightInfoController(IFlightInfoRepository repository, IHubContext<FlightStatusHub.FlightStatusHub> hubContext)
    {
        _repository = repository;
        _hubContext = hubContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var data = await _repository.GetAllAsync();
        return Ok(data);
    }

   
    [HttpPut("status")]
    public async Task<IActionResult> UpdateStatus([FromBody] UpdateFlightStatusRequest req)
    {
        bool result = await _repository.UpdateFlightStatusAsync(req.FlightId, req.NewStatus);
        if (!result)
            return NotFound();

        // FlightId-аар FlightInfo-г шууд авна
        var updatedFlight = await _repository.GetByFlightIdAsync(req.FlightId);

        if (updatedFlight != null)
        {
            // FlightNumber болон Status-г SignalR-ээр илгээ
            await _hubContext.Clients.All.SendAsync("ReceiveFlightStatus", updatedFlight.FlightNumber, updatedFlight.Status);
        }

        return Ok();
    }
    [HttpGet("{flightId}")]
    public async Task<IActionResult> GetById(int flightId)
    {
        var info = await _service.GetByFlightIdAsync(flightId);
        if (info == null) return NotFound();
        return Ok(info);
    }
    [HttpGet("byNumber")]
    public async Task<IActionResult> GetByNumber([FromQuery] string flightNumber)
    {
        var info = await _repository.GetByFlightNumberAsync(flightNumber);
        if (info == null) return NotFound();
        return Ok(info);
    }
}
