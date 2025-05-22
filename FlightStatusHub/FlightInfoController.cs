using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLibrary.DTO;


// FlightAPI/Controllers/FlightInfoController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[ApiController]
[Route("api/[controller]")]
public class FlightInfoController : ControllerBase
{
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
        // 1. Өгөгдлийн сан дахь нислэгийн төлөвийг шинэчилнэ
        bool result = await _repository.UpdateFlightStatusAsync(req.FlightId, req.NewStatus);
        if (!result)
            return NotFound();

        // 2. Шинэчилсэн нислэгийн мэдээллийг авна
        var allFlights = await _repository.GetAllAsync();
        var updatedFlight = allFlights.FirstOrDefault(f => f.FlightNumber == req.FlightId.ToString());
        // FlightId-г FlightNumber-тэй тааруулах бол өөрчлөлт хийж болно

        // 3. SignalR-ээр шинэ статусыг бүх клиент рүү push хийнэ
        if (updatedFlight != null)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveFlightStatus", updatedFlight.FlightNumber, updatedFlight.Status);
        }

        return Ok();
    }
}
