using HotelBookingAPI.Data.Entities;
using HotelBookingAPI.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Data.Repositories;

internal class BookingRepository : IBookingRepository
{
    public BookingRepository(HotelBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public HotelBookingDbContext _dbContext { get; }

    public async Task<int> CreateBookingEntity(BookingEntity bookingToCreate)
    {
        var entity = await _dbContext.AddAsync(bookingToCreate);
        await _dbContext.SaveChangesAsync();
        if (entity.Entity != null && entity.Entity.BookingId != null) { return (int)entity.Entity.BookingId; }

        return 0;
        // Throw Exception here
    }

    public async Task<BookingEntity?> GetBooking(int bookingId)
    {
        return await _dbContext.Bookings.Where(booking => booking.BookingId == bookingId).SingleOrDefaultAsync();
    }
}
