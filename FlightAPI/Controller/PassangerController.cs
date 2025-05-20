using AutoMapper;
using FlightLibrary;
using FlightLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Runtime.InteropServices;

[ApiController]
[Route("api/[controller]")]
public class PassengerController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly AppDbContext _context;

    public PassengerController(IMapper mapper, AppDbContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet("{passportNumber}")]
    public ActionResult<PassengerDto> GetByPassport(string passportNumber)
    {
        var passenger = _context.Passengers
            .Include(p => p.Seat)
            .FirstOrDefault(p => p.PassportNumber == passportNumber);

        if (passenger == null)
            return NotFound();

        return Ok(_mapper.Map<PassengerDto>(passenger));
    }

    [HttpPost("assign-seat")]
    public IActionResult AssignSeat(PassengerDto dto)
    {
        var passenger = _context.Passengers.Find(dto.Id);
        var seat = _context.Seats.Find(dto.SeatCode);

        if (passenger == null || seat == null || seat.IsAssigned)
            return BadRequest("Invalid or already assigned seat");

        passenger.SeatId = dto.SeatCode;
        seat.IsAssigned = true;

        _context.SaveChanges();
        return Ok();
    }
}
