using System;
using System.Collections.Generic;
using System.Text;
using BookingEntity = Booking.com.Domain.Entities.Booking;
using Booking.com.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Booking.com.Application.Interfaces;

namespace Booking.com.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _dbContext;

        public BookingRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<BookingEntity?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Bookings
                .FirstOrDefaultAsync(booking => booking.Id == id);
        }

        public async Task<List<BookingEntity>> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.Bookings
                .Where(booking => booking.UserId == userId)
                .ToListAsync();
        }

        public async Task<bool> HasBookingAsync(
            Guid roomId,
            DateTime checkIn,
            DateTime checkOut)
        {
            return await _dbContext.Bookings
                .AnyAsync(booking =>
                    booking.RoomId == roomId &&
                    booking.CheckIn < checkOut &&
                    booking.CheckOut > checkIn);
        }

        public void Add(BookingEntity booking)
        {
            _dbContext.Bookings.Add(booking);
        }
    }
}

