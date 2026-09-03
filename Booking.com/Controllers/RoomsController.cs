using Booking.com.Application.DTOs.Rooms;
using Booking.com.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Booking.com.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly IRoomService _roomService;

    public RoomsController(IRoomService roomService)
    {
        _roomService = roomService;
    }

    [HttpGet]
    public async Task<ActionResult<List<RoomDto>>> GetAll()
    {
        var rooms = await _roomService.GetAllAsync();

        return Ok(rooms);
    }
}