using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Domain.Enums;
namespace Booking.com.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public UserRole Role { get; set; };
    }
}
