using FlightLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightAPI.Services;

namespace FlightAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _service;
        public FlightController(IFlightService service) => _service = service;

        [HttpGet("passenger/{passportNumber}")]
        public async Task<ActionResult<PassengerDto>> GetPassenger(string passportNumber)
        {
            var passenger = await _service.GetPassengerByPassportAsync(passportNumber);
            return passenger != null ? Ok(passenger) : NotFound();
        }

        [HttpPost("assign-seat")]
        public async Task<IActionResult> AssignSeat(string passportNumber, string seatCode)
        {
            var result = await _service.AssignSeatAsync(passportNumber, seatCode);
            return result ? Ok() : BadRequest("Суудал аль хэдийнээ оноогдсон байна.");
        }

       // [HttpPost("update-status")]
        //public async Task<IActionResult> UpdateFlightStatus([FromBody] FlightStatusUpdateDTO dto)
        //{
        //    await _service.UpdateFlightStatusAsync(dto.FlightId, dto.NewStatus);
        //    return Ok();
        //}
    }
    }


