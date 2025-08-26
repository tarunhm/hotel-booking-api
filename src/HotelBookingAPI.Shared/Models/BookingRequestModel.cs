using HotelBookingAPI.Shared.ValidatorAttributes;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Shared.Models;

public class BookingRequestModel
{
    [Required]
    public DateOnly CheckInDate { get; set; }

    [Required]
    [MinValue(1)]
    public int Nights { get; set; }

    [Required]
    public int RoomId { get; set; }

    [MaxLength(50)]
    public string? BookingUser { get; set; } = null!;
}
