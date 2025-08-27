using HotelBookingAPI.Data.Entities;
using HotelBookingAPI.Shared.Models;

namespace HotelBookingAPI.Data.Mappers;

internal static class RoomMapper
{
    internal static RoomHotelModel MapEntityToHotelModel(this RoomEntity entity) => new()
    {
        RoomId = entity.Id,
        HotelId = entity.HotelId,
        HotelName = entity.Hotel?.HotelName!,
        RoomType = entity.RoomType,
        RoomCapacity = entity.RoomCapacity
    };

    internal static RoomModel MapEntityToModel(this RoomEntity entity) => new()
    {
        RoomId = entity.Id,
        RoomType = entity.RoomType,
        RoomCapacity = entity.RoomCapacity
    };
}