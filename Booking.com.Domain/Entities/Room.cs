using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Booking.com.Domain.Enums;

namespace Booking.com.Domain.Entities
{
    public class Room
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public RoomClass Class { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; } 
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
