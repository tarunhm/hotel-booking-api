namespace HotelBookingAPI.Shared.Models;

public class RoomHotelModel : RoomModel
{
    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;
}

public class RoomModel
{
    public int RoomId { get; set; }

    public string RoomType { get; set; } = null!;

    public int RoomCapacity { get; set; }
}