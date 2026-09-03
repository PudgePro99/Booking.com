using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Domain.Entities;

namespace Booking.com.Application.Interfaces
{
    public interface IRoomRepository
    {
        Task<Room?> GetByIdAsync(Guid Id);
        Task<List<Room>> GetAllAsync();
        void Add(Room room);
        void Delete(Room room);
    }
}
