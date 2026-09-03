using Booking.com.Application.Interfaces;
namespace Booking.com.Infrastructure.Data;

public class SaveChanges : ISaveChanges
{
    private readonly AppDbContext _dbContext;
    public SaveChanges(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}