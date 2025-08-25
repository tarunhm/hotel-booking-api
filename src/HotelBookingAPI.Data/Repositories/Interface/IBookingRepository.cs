using HotelBookingAPI.Data.Entities;

namespace HotelBookingAPI.Data.Repositories.Interface;

public interface IBookingRepository
{
    Task<BookingEntity?> GetBooking(int bookingId);

    Task<int> CreateBookingEntity(BookingEntity bookingToCreate);
}
