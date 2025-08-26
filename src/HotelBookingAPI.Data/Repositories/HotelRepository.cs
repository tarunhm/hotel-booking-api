using HotelBookingAPI.Data.Entities;
using HotelBookingAPI.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Data.Repositories;

internal class HotelRepository : IHotelRepository
{
    public HotelRepository(HotelBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public HotelBookingDbContext _dbContext { get; }

    public async Task<IList<HotelEntity>> GetAll()
    {
        return await _dbContext.Hotels
                    .AsNoTracking()
                    .Include(hotel => hotel.Rooms)
                    .ToListAsync();
    }

    public async Task<IList<HotelEntity>> GetByName(string hotelSubstring)
    {
        return await _dbContext.Hotels
                    .AsNoTracking()
                    .Where(hotel => !string.IsNullOrEmpty(hotel.HotelName) 
                        && hotel.HotelName.ToLower().Contains(hotelSubstring.ToLower()))
                    .Include(hotel => hotel.Rooms)
                    .ToListAsync();
    }
}