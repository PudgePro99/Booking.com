using Booking.com.Application.DTOs.Bookings;
using Booking.com.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking.com.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BookingDto>> GetById(Guid id)
    {
        var booking = await _bookingService.GetByIdAsync(id);

        if (booking is null)
            return NotFound();

        return Ok(booking);
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<ActionResult<List<BookingDto>>> GetByUserId(Guid userId)
    {
        var bookings = await _bookingService.GetByUserIdAsync(userId);

        return Ok(bookings);
    }

    [HttpPost]
    public async Task<ActionResult<BookingDto>> Create(CreateBookingDto dto)
    {
        try
        {
            var booking = await _bookingService.CreateAsync(dto);

            return Ok(booking);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
}