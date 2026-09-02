using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Domain.Entities;
using Booking.com.Infrastructure.Data;
using Booking.com.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Booking.com.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly AppDbContext _dbContext;
        public RoomRepository(AppDbContext _dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Room?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Rooms.FirstOrDefaultAsync(room => room.Id == id);
        }
    }
}
