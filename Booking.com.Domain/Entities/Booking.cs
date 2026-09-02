using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.com.Domain.Entities
{
    public class Booking
    {
        public Guid Id  { get; set; }
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CheckIn {  get; set; }
        public DateTime CheckOut { get; set; }
        public Room Room { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
