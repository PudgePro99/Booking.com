using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Application.DTOs.Rooms;
using Booking.com.Application.Interfaces;
namespace Booking.com.Application.Interfaces
{
    public interface IRoomService
    {
        Task<RoomDto?> GetByIdAsync(Guid id);
        Task<List<RoomDto>> GetAllAsync();
        Task<RoomDto> CreateAsync(CreateRoomDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
