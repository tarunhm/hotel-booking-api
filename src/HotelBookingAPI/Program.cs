using HotelBookingAPI;
using HotelBookingAPI.Data;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDataLayerAccess();

builder.Services.AddOptions<DatabaseServiceOptions>()
            .Bind(builder.Configuration.GetRequiredSection("Database"))
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