using HotelBookingAPI.Data.Entities;
using HotelBookingAPI.Shared.Models;

namespace HotelBookingAPI.Data.Mappers;

internal static class BookingMapper
{
    internal static BookingModel MapEntityToModel(this BookingEntity entity) => new()
    {
        BookingId = entity.BookingId,
        BookingUser = entity.BookingUser,
        CheckInDate = DateOnly.FromDateTime(entity.CheckInDate),
        CheckOutDate = DateOnly.FromDateTime(entity.CheckOutDate),
        RoomId = entity.RoomId,
        RoomType = entity.Room.RoomType,
        RoomCapacity = entity.Room.RoomCapacity,
        HotelId = entity.Room.HotelId,
        HotelName = entity.Room.Hotel?.HotelName!
    };

    internal static BookingEntity MapRequestModelToEntity(this BookingRequestModel requestModel) => new()
    {
        RoomId = requestModel.RoomId,
        CheckInDate = requestModel.CheckInDate.ToDateTime(new TimeOnly()),
        CheckOutDate = requestModel.CheckInDate.AddDays(requestModel.Nights).ToDateTime(new TimeOnly()),
        BookingUser = requestModel.BookingUser
    };
}
