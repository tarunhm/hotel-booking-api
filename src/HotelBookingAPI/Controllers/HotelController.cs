using HotelBookingAPI.Data.Models;
using HotelBookingAPI.Data.Services.Interface;
using Microsoft.AspNetCore.Mvc;
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
        catch
        {
            return StatusCode(500, "An Internal Server Error Occured");
        }
    }

    [HttpGet]
    public async Task<ActionResult<IList<HotelModel>>> GetAll()
    {
        try
        {
            var hotels = await _hotelService.GetAll();
            if (hotels.Any()) { return Ok(hotels); }

            return NotFound();
        }
        catch
        {
            return StatusCode(500, "An Internal Server Error Occured");
        }
    }
}
