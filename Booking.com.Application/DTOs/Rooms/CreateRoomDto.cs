using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Booking.com.Domain.Enums;

namespace Booking.com.Application.DTOs.Rooms
{
    public class CreateRoomDto
    {
        public int Number {  get; set; }
        public RoomClass Class { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
