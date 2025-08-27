using HotelBookingAPI.Data.Services.Interface;
using HotelBookingAPI.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Controllers;

[Route("api/[controller]/[action]")]
public class HotelController: ControllerBase
{
    private IHotelService _hotelService { get; set; }

    public HotelController(IHotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [SwaggerOperation(
        Summary = "Fetches Hotels by search term",
        Description = "Returns hotel information whose name contains the search term input.",
        OperationId = $"{nameof(Get)}Hotels"
    )]
    [SwaggerResponse(200, "Hotels were successfully returned", typeof(RoomModel))]
    [SwaggerResponse(400, "Invalid request")]
    [SwaggerResponse(404, "No hotels found containing search term")]
    [SwaggerResponse(500, "Unexpected error occured when fetching hotels")]
    [HttpGet]
    public async Task<ActionResult<IList<HotelModel>>> Get([Required] string searchTerm)
    {
        if (!ModelState.IsValid) {  return BadRequest(ModelState); }

        try
        {
            var hotels = await _hotelService.GetBySubstring(searchTerm);
            if (hotels.Any()) { return Ok(hotels); }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [SwaggerOperation(
        Summary = "Fetches All Hotels",
        Description = "Returns hotel information including room details.",
        OperationId = $"{nameof(GetAll)}Hotels"
    )]
    [SwaggerResponse(200, "Hotels were successfully returned", typeof(RoomModel))]
    [SwaggerResponse(400, "Invalid request")]
    [SwaggerResponse(404, "No hotels found")]
    [SwaggerResponse(500, "Unexpected error occured when fetching hotels")]
    [HttpGet]
    public async Task<ActionResult<IList<HotelModel>>> GetAll()
    {
        try
        {
            var hotels = await _hotelService.GetAll();
            if (hotels.Any()) { return Ok(hotels); }

            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
