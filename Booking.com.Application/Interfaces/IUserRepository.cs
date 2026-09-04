using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Domain.Entities;


namespace Booking.com.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<List<User>> GetAllAsync();
        void Add(User user);
    }
}
