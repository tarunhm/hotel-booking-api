using HotelBookingAPI.Data.Entities;

namespace HotelBookingAPI.Data.Repositories.Interface;

public interface IHotelRepository
{
    Task<IList<HotelEntity>> GetHotels(string hotelSubstring);

    Task<IList<HotelEntity>> GetAll();
}
