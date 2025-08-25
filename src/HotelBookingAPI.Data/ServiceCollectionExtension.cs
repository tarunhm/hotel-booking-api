using HotelBookingAPI.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBookingAPI.Data;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDataLayerAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<HotelBookingDbContext>();
        serviceCollection.AddScoped<IHotelRoomRepository, HotelRoomRepository>();
        return serviceCollection;
    }
}
