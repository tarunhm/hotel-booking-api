using HotelBookingAPI.Data.Services.Interface;
using HotelBookingAPI.Shared.Models;
using Microsoft.AspNetCore.Mvc;
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
            return StatusCode(500, ex);
        }
    }

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
            return StatusCode(500, ex);
        }
    }
}
