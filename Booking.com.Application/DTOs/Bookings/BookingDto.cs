using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Application.DTOs.Rooms;
using Booking.com.Application.DTOs.Users;
namespace Booking.com.Application.DTOs.Bookings
{
    public class BookingDto
    {
        public Guid Id {  get; set; }
        public Guid RoomId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
