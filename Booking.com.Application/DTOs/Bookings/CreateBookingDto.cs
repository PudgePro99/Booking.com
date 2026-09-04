using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Application.DTOs.Bookings;

namespace Booking.com.Application.DTOs.Bookings
{
    public class CreateBookingDto
    {
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
