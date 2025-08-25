using HotelBookingAPI.Data.Entities;

namespace HotelBookingAPI.Data.Repositories.Interface;

public interface IHotelRoomRepository
{
    Task<IList<HotelEntity>> GetHotels(string hotelSubstring)
}
