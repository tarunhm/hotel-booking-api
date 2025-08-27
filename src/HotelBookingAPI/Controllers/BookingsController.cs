using HotelBookingAPI.Data.Services.Interface;
using HotelBookingAPI.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Controllers;

[Route("api/[controller]/[action]")]
public class BookingsController : ControllerBase
{
    private IBookingService _bookingService { get; }

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [SwaggerOperation(
        Summary = "Fetches a Hotel Booking by Booking ID",
        Description = "Returns a hotel room booking by the unique Booking ID, if the booking exists.",
        OperationId = $"{nameof(GetById)}Booking"
    )]
    [SwaggerResponse(200, "Booking was successfully returned", typeof(BookingModel))]
    [SwaggerResponse(400, "Invalid request")]
    [SwaggerResponse(404, "Booking was not found")]
    [SwaggerResponse(500, "Unexpected error occured when fetching booking")]
    [HttpGet]
    public async Task<ActionResult<BookingModel>> GetById([Required] int id)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        try
        {
            var booking = await _bookingService.GetById(id);

            if (booking == null) { return NotFound(); }
            return Ok(booking);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [SwaggerOperation(
        Summary = "Create a Booking",
        Description = "Creates a booking when the room is available for given dates. On success, returns the unique booking identifier.",
        OperationId = $"{nameof(Create)}Booking"
    )]
    [SwaggerResponse(200, "Booking was successfully created", typeof(int))]
    [SwaggerResponse(400, "Invalid request")]
    [SwaggerResponse(500, "Unexpected error occured when creating booking")]
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody][Required] BookingRequestModel booking)
    {
        if (!ModelState.IsValid) { return BadRequest(ModelState); }

        try
        {
            return await _bookingService.CreateBooking(booking);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"{ex.Message}: {ex.InnerException}");
        }
    }
}
