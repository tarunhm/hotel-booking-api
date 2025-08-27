using HotelBookingAPI;
using HotelBookingAPI.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDataLayerAccess();

var databaseOptions = builder.Configuration.GetRequiredSection("Database");
if (string.IsNullOrEmpty(databaseOptions.GetSection("Password").Value))
{
    databaseOptions["Password"] = Environment.GetEnvironmentVariable("DatabasePassword");
}

builder.Services.AddOptions<DatabaseServiceOptions>()
            .Bind(databaseOptions)
            .ValidateDataAnnotations()
            .ValidateOnStart();

builder.Services.AddSwaggerGen(config =>
{
    config.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hotel Booking API",
        Version = "v1"
    });

    config.EnableAnnotations();
});

var app = builder.Build();

app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();