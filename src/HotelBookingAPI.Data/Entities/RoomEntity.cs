using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelBookingAPI.Data.Entities;

[Table("ROOMS", Schema = "HOTEL_BOOKING")]
internal class RoomEntity
{
    [Key]
    [Column("ROOM_ID")]
    public int Id { get; set; }

    [Column("HOTEL_ID")]
    public int HotelId { get; set; }

    [Column("ROOM_TYPE")]
    public string RoomType { get; set; } = null!;

    [Column("ROOM_CAPACITY")]
    public int RoomCapacity { get; set; }

    #region relationships

    public HotelEntity Hotel { get; set; } = null!;

    public ICollection<BookingEntity> Bookings { get; set; } = [];

    #endregion relationships
}