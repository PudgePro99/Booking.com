using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Booking.com.Application.DTOs.Users;
using Booking.com.Application.Interfaces;
using Booking.com.Application.Services;

namespace Booking.com.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserDto>> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Create(CreateUserDto dto)
        {
            var user = await _userService.CreateAsync(dto);
            return Ok(user);
        }
    }
}
    
    
