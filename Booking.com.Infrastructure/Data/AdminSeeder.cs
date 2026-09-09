using System;
using System.Collections.Generic;
using System.Text;
using Booking.com.Domain.Entities;
using Booking.com.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Booking.com.Infrastructure.Data;

public static class AdminSeeder
{
    public static async Task SeedAsync(AppDbContext dbContext)
    {
        var adminExists = await dbContext.Users
            .AnyAsync(user => user.Role == UserRole.Admin);

        if (adminExists)
            return;

        var admin = new User
        {
            Id = Guid.NewGuid(),
            Name = "admin",
            Role = UserRole.Admin
        };

        dbContext.Users.Add(admin);

        await dbContext.SaveChangesAsync();
    }
}