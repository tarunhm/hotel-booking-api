using HotelBookingAPI.Data.Services.Interface;
using HotelBookingAPI.Shared.Models;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet]
    public ActionResult<RoomModel> Get([Required] AvailibilityRequestModel availibilityRequest)
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
