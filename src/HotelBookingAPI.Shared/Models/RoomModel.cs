namespace HotelBookingAPI.Shared.Models;

public class RoomModel
{
    public int RoomId { get; set; }

    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public string RoomType { get; set; } = null!;

    public int RoomCapacity { get; set; }
}