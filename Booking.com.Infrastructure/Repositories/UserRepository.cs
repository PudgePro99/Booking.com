using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Application.Interfaces;
using Booking.com.Domain.Entities;
using Booking.com.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Booking.com.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public void Add(User user)
        {
            _dbContext.Users.Add(user);
        }

    }
}
