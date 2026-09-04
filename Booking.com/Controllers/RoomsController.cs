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
    [HttpPost]
    public async Task<ActionResult<RoomDto>>
        Create(CreateRoomDto dto)
    {
        var room = await
            _roomService.CreateAsync(dto);
        return Ok(room);
    }
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RoomDto>> GetById(Guid id)
    {
        var room = await _roomService.GetByIdAsync(id);
        if (room == null)
            return NotFound();
        return Ok(room);
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _roomService.DeleteAsync(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}