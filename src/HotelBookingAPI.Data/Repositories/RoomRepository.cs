using HotelBookingAPI.Data.Entities;
using HotelBookingAPI.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Data.Repositories;

internal class RoomRepository : IRoomRepository
{
    public RoomRepository(HotelBookingDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public HotelBookingDbContext _dbContext { get; }

    public IEnumerable<RoomEntity> GetByCapacity(int people)
    {
        return _dbContext.Rooms
            .Where(room => room.RoomCapacity >= people)
            .Include(room => room.Bookings)
            .Include(room => room.Hotel)
            .AsNoTracking()
            .AsEnumerable();
    }

    public async Task<bool> ExistsById(int roomId)
    {
        return await _dbContext.Rooms.AnyAsync(room => room.Id.Equals(roomId));
    }
}
