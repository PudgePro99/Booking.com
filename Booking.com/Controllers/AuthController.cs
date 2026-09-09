using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Booking.com.Application.Interfaces;
using Booking.com.Application.DTOs.Auth;

namespace Booking.com.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginDto dto)
    {
        var result = await _authService.LoginAsync(dto);

        if (result is null)
            return Unauthorized();

        return Ok(result);
    }
}