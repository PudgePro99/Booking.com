using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Booking.com.Application.DTOs.Auth;
using Booking.com.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Booking.com.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(
        IUserRepository userRepository,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<LoginResponseDto?> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByNameAsync(dto.Name);

        if (user is null)
            return null;

        var token = GenerateToken(user);

        return new LoginResponseDto
        {
            Token = token
        };
    }

    private string GenerateToken(Domain.Entities.User user)
    {
        var claims = new List<Claim>
        {
            new Claim(
                ClaimTypes.NameIdentifier,
                user.Id.ToString()),

            new Claim(
                ClaimTypes.Name,
                user.Name),

            new Claim(
                ClaimTypes.Role,
                user.Role.ToString())
        };

        var key = _configuration["Jwt:Key"];

        if (string.IsNullOrEmpty(key))
            throw new InvalidOperationException("JWT key is not configured.");

        var securityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(key));

        var credentials = new SigningCredentials(
            securityKey,
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}