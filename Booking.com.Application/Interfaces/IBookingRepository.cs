using System;
using System.Collections.Generic;
using System.Text;
using BookingEntity = Booking.com.Domain.Entities.Booking;
namespace Booking.com.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<BookingEntity?> GetByIdAsync(Guid id);
        Task<List<BookingEntity>> GetByUserIdAsync(Guid userId);
        Task<bool> HasBookingAsync(
            Guid roomId,
            DateTime checkIn,
            DateTime checkOut);
        void Add(BookingEntity booking);
    }
}
