using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Booking.com.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<>
    }
}
