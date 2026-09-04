using Booking.com.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.com.Application.DTOs.Users
{
    public class UserDto
    {
        public Guid Id {  get; set; }
        public string Name { get; set; } = string.Empty;

        public UserRole Role { get; set; }
    }
}
