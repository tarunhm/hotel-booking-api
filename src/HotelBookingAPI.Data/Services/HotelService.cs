using HotelBookingAPI.Data.Mappers;
using HotelBookingAPI.Data.Repositories.Interface;
using HotelBookingAPI.Data.Services.Interface;
using HotelBookingAPI.Shared.Models;

namespace HotelBookingAPI.Data.Services;

public class HotelService : IHotelService
{
    public HotelService(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    public IHotelRepository _hotelRepository { get; }

    public async Task<IList<HotelModel>> GetAll()
    {
        return (await _hotelRepository.GetAll()).Select(HotelMapper.MapEntityToModel).ToList();
    }

    public async Task<IList<HotelModel>> GetBySubstring(string substring)
    {
        return (await _hotelRepository.GetByName(substring)).Select(HotelMapper.MapEntityToModel).ToList();
    }
}
