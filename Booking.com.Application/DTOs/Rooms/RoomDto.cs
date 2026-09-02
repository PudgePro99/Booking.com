using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Domain.Enums;

namespace Booking.com.Application.DTOs.Rooms
{
    //Передача данных на фронт
    public class RoomDto
    {
        public Guid Id {  get; set; }
        public int Number { get; set; }
        public RoomClass Class {  get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
    }
}
