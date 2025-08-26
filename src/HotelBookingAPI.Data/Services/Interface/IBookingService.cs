using HotelBookingAPI.Shared.Models;

namespace HotelBookingAPI.Data.Services.Interface;

public interface IBookingService
{
    Task<int> CreateBooking(BookingRequestModel bookingRequest);

    Task<BookingModel?> GetById(int id);

    IList<RoomModel> GetAvailableRooms(int people, DateOnly checkInDate, int duration);
}
