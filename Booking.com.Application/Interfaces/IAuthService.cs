using Booking.com.Application.DTOs.Auth;

namespace Booking.com.Application.Interfaces;

public interface IAuthService
{
    Task<LoginResponseDto?> LoginAsync(LoginDto dto);
}