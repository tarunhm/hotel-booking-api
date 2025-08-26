using HotelBookingAPI.Shared.ValidatorAttributes;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Shared.Models;

public class AvailibilityRequestModel
{
    [Required]
    [FutureDate]
    public DateOnly CheckInDate { get; set; }

    [Required]
    [MinValue(1)]
    public int Nights { get; set; }

    [Required]
    [MinValue(1)]
    public int People { get; set; }
}
