using HotelBookingAPI.Data.Repositories;
using HotelBookingAPI.Data.Repositories.Interface;
using HotelBookingAPI.Data.Services;
using HotelBookingAPI.Data.Services.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace HotelBookingAPI.Data;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDataLayerAccess(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContext<HotelBookingDbContext>();
        serviceCollection.AddScoped<IHotelRepository, HotelRepository>();
        serviceCollection.AddScoped<IRoomRepository, RoomRepository>();
        serviceCollection.AddScoped<IBookingRepository, BookingRepository>();
        serviceCollection.AddScoped<ITestDataRepository, TestDataRepository>();

        serviceCollection.AddScoped<IBookingService, BookingService>();
        serviceCollection.AddScoped<IHotelService, HotelService>();

        return serviceCollection;
    }
}
