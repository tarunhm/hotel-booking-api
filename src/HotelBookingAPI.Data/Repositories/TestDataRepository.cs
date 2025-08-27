using HotelBookingAPI.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Data.Repositories;

internal class TestDataRepository : ITestDataRepository
{
    HotelBookingDbContext _dbContext { get; set; }

    public TestDataRepository(HotelBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ResetData()
    {
        var storedProc = 
            "BEGIN " +
            "   hotel_booking.reset_data(); " +
            "   commit;" +
            "END;";
        await _dbContext.Database.ExecuteSqlRawAsync(storedProc);
    }

    public async Task SeedData()
    {
        if (_dbContext.Bookings.AsNoTracking().Any() 
            || _dbContext.Hotels.AsNoTracking().Any() 
            || _dbContext.Rooms.AsNoTracking().Any())
        {
            throw new InvalidOperationException("Existing data in database. Please reset data before seeding");
        }

        var storedProc =
            "BEGIN " +
            "   hotel_booking.seed_data(); " +
            "   commit;" +
            "END;";
        await _dbContext.Database.ExecuteSqlRawAsync(storedProc);
    }
}
