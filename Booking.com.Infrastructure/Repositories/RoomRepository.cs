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
        public RoomRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Room?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Rooms.FirstOrDefaultAsync(room => room.Id == id);
        }
        public  async Task<List<Room>> GetAllAsync()
        {
            return await _dbContext.Rooms.ToListAsync();
        }
        public void Add(Room room)
        {
            _dbContext.Rooms.Add(room);
        }
        public void Delete(Room room)
        {
            _dbContext.Rooms.Remove(room);
        }

    }
}
