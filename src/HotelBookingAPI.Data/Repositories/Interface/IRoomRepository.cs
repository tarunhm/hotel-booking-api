using HotelBookingAPI.Data.Entities;

namespace HotelBookingAPI.Data.Repositories.Interface;

public interface IRoomRepository
{
    IEnumerable<RoomEntity> GetByCapacity(int people);

    Task<bool> ExistsById(int roomId);
}