using HotelBookingAPI.Data.Entities;

namespace HotelBookingAPI.Data.Repositories.Interface;

public interface IRoomRepository
{
    RoomEntity? GetByID(int id);

    IEnumerable<RoomEntity> GetByCapacity(int people);

    Task<bool> ExistsById(int roomId);
}