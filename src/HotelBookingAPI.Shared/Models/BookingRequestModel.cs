using HotelBookingAPI.Shared.ValidatorAttributes;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Shared.Models;

public class BookingRequestModel
{
    [Required]
    [FutureDate]
    [SwaggerParameter("Check in date in format dd-mm-yyyy")]
    public DateOnly CheckInDate { get; set; }

    [Required]
    [MinValue(1)]
    [SwaggerParameter("Number of nights the hotel room should be booked for")]
    public int Nights { get; set; }

    [Required]
    [SwaggerParameter("The unique identifier of the room to book")]
    public int RoomId { get; set; }

    [MaxLength(50)]
    [SwaggerParameter("Details of the person booking the hotel room")]
    public string? BookingUser { get; set; } = null!;
}
