using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.com.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
