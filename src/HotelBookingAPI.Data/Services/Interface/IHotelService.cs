using HotelBookingAPI.Shared.Models;

namespace HotelBookingAPI.Data.Services.Interface;

public interface IHotelService
{
    Task<IList<HotelModel>> GetAll();
    
    Task<IList<HotelModel>> GetBySubstring(string substring);
}
