using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Domain.Entities;
using Booking.com.Application.DTOs;
using Booking.com.Application.Interfaces;
using Booking.com.Application.DTOs.Users;
using Booking.com.Domain.Enums;

namespace Booking.com.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ISaveChanges _saveChanges;
        public UserService(IUserRepository userRepository, ISaveChanges saveChanges)
        {
            _userRepository = userRepository;
            _saveChanges = saveChanges;
        }
        public async Task<UserDto?> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                return null;
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
            };
        }
        public async Task<List<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.Name,
            }).ToList();
        }
        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Role = UserRole.User
            };
            _userRepository.Add(user);
            await _saveChanges.SaveChangesAsync();
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role
            };
        }
    }
}
