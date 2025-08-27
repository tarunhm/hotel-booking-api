using Microsoft.OpenApi.Extensions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace HotelBookingAPI;

public static class SwaggerConfig
{
    public static WebApplication ConfigureSwagger(this WebApplication app)
    {
        app.UseSwagger(options => options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerUI();
        }

        // Generate swagger.json on application run
        ISwaggerProvider sw = app.Services.GetRequiredService<ISwaggerProvider>();
        OpenApiDocument doc = sw.GetSwagger("v1", null, "/");
        string swaggerFile = doc.SerializeAsJson(Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_0);
        File.WriteAllText("swaggerfile.json", swaggerFile);

        return app;
    }
}
