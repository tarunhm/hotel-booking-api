using HotelBookingAPI.Data.Entities;

namespace HotelBookingAPI.Data.Repositories.Interface;

public interface IHotelRepository
{
    Task<IList<HotelEntity>> GetByName(string hotelSubstring);

    Task<IList<HotelEntity>> GetAll();
}