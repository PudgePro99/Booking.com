using Booking.com.Application.DTOs.Bookings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Booking.com.Application.Interfaces
{
    public interface IBookingService
    {
        Task<BookingDto?> GetByIdAsync(Guid id);
        Task<List<BookingDto>> GetByUserIdAsync(Guid userId);
        Task<BookingDto> CreateAsync(CreateBookingDto dto);
    }
}
