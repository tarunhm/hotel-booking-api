using HotelBookingAPI.Data.Services.Interface;
using HotelBookingAPI.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Controllers;

[Route("api/[controller]/[action]")]
public class AvailableRoomsController : ControllerBase
{
    private IBookingService _bookingService { get; }

    public AvailableRoomsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [SwaggerOperation(
        Summary = "Fetches Available Rooms",
        Description = "Returns available hotel rooms for given dates and room occupancy.",
        OperationId = $"{nameof(Get)}AvailableRooms"
    )]
    [SwaggerResponse(200, "Rooms were successfully returned", typeof(RoomHotelModel))]
    [SwaggerResponse(400, "Invalid request")]
    [SwaggerResponse(404, "No available rooms found for given dates and number of people")]
    [SwaggerResponse(500, "Unexpected error occured when fetching booking")]
    [HttpGet]
    public ActionResult<RoomHotelModel> Get([Required] AvailibilityRequestModel availibilityRequest)
    {
        if (!ModelState.IsValid) 
        {
            return BadRequest(ModelState); 
        }

        try
        {
            var booking = _bookingService.GetAvailableRooms(availibilityRequest.People, availibilityRequest.CheckInDate, availibilityRequest.Nights);

            if (!booking.Any()) { return NotFound(); }

            return Ok(booking);
        }
        catch (Exception ex) 
        { 
            return StatusCode(500, ex.Message);
        }
    }
}
