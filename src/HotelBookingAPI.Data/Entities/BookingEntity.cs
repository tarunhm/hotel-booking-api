using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Data.Entities;

[Table("BOOKINGS", Schema = "HOTEL_BOOKING")]
internal class BookingEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("BOOKING_ID")]
    public int? BookingId { get; init; } = null!;

    [Column("ROOM_ID")]
    public int RoomId { get; set; }

    [Column("CHECK_IN_DATE")]
    public DateOnly CheckInDate { get; set; }

    [Column("CHECK_OUT_DATE")]
    public DateOnly CheckOutDate { get; set; }

    [Column("BOOKING_USERNAME")]
    public string? BookingUser { get; set; } = null!;

    #region relationships

    public RoomEntity Room { get; set; } = null!;

    #endregion relationships
}
