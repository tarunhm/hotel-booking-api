using HotelBookingAPI.Data.Repositories.Interface;
using HotelBookingAPI.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HotelBookingAPI.Controllers;

[Route("api/[controller]/[action]")]
public class TestDataController : ControllerBase
{
    private ITestDataRepository _testDataRepository { get; set; }

    public TestDataController(ITestDataRepository testDataRepository)
    {
        _testDataRepository = testDataRepository;
    }

    [SwaggerOperation(
        Summary = "Reset data",
        Description = "Removes all bookings, hotels and rooms from the system.",
        OperationId = $"{nameof(Reset)}"
    )]
    [SwaggerResponse(200, "Data successfully reset", typeof(RoomModel))]
    [HttpDelete]
    public async Task<ActionResult> Reset()
    {
        try
        {
            await _testDataRepository.ResetData();
            return Ok();
            
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [SwaggerOperation(
        Summary = "Seeds data",
        Description = "Seeds hotels and rooms into the system for testing purposes.",
        OperationId = $"{nameof(Seed)}"
    )]
    [SwaggerResponse(200, "Data successfully reset and seeded", typeof(RoomModel))]
    [HttpPut]
    public async Task<ActionResult> Seed()
    {
        try
        {
            await _testDataRepository.SeedData();
            return Ok();

        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
