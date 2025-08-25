namespace HotelBookingAPI.Data.Models;

public class HotelModel
{
    public int Id { get; set; }

    public string? HotelName { get; set; }

    public ICollection<RoomModel> Rooms { get; set; } = [];
}
