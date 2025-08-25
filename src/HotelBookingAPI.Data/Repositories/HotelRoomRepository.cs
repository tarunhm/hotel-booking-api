using HotelBookingAPI.Data.Entities;
using HotelBookingAPI.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Data.Repositories;

internal class HotelRoomRepository : IHotelRoomRepository
{
    public HotelRoomRepository(HotelBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public HotelBookingDbContext _dbContext { get; }

    public async Task<IList<HotelEntity>> GetHotels(string hotelSubstring)
    {
        return await _dbContext.Hotels
                    .AsNoTracking()
                    .Include(hotel => hotel.Rooms)
                    .ToListAsync();
    }
}
