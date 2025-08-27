using HotelBookingAPI.Data.Entities;
using HotelBookingAPI.Shared.Models;

namespace HotelBookingAPI.Data.Mappers;

internal static class HotelMapper
{
    internal static HotelModel MapEntityToModel(this HotelEntity entity) => new()
    {
        Id = entity.Id,
        HotelName = entity.HotelName,
        Rooms = entity.Rooms.Select(RoomMapper.MapEntityToModel).ToList()
    };
}
