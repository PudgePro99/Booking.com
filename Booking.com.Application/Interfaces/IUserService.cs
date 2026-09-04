using Booking.com.Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.com.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetByIdAsync(Guid id);
        Task <List<UserDto>> GetAllAsync();
        Task<UserDto> CreateAsync(CreateUserDto dto);
    }
}
