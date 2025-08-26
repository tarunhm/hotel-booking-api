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

    public RoomEntity? GetByID(int id)
    {
        var rooms = _dbContext.Rooms
            .Where(room => room.Id == id)
            .Include(room => room.Bookings)
            .Include(room => room.Hotel)
            .AsNoTracking();

        if (rooms.Count() != 1) { return null; }
        return rooms.Single();
    }

    public IEnumerable<RoomEntity> GetByCapacity(int people)
    {
        return _dbContext.Rooms
            .Where(room => room.RoomCapacity >= people)
            .Include(room => room.Bookings)
            .Include(room => room.Hotel)
            .AsNoTracking()
            .AsEnumerable();
    }
}
