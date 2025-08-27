namespace HotelBookingAPI.Data.Repositories.Interface;

public interface ITestDataRepository
{
    Task ResetData();

    Task SeedData();
}
