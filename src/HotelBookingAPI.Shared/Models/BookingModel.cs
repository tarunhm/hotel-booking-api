namespace HotelBookingAPI.Shared.Models;

public class BookingModel
{
    public int BookingId { get; set; }

    public string? BookingUser { get; set; } = null!;

    public DateOnly CheckInDate { get; set; } 

    public DateOnly CheckOutDate { get; set; }

    public int RoomId { get; set; }

    public string? RoomType { get; set; } = null!;

    public int RoomCapacity { get; set; }

    public int HotelId { get; set; }

    public string? HotelName { get; set; } = null!;
}