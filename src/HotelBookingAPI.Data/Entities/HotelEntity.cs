using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBookingAPI.Data.Entities;

[Table("HOTELS", Schema = "HOTEL_BOOKING")]
internal class HotelEntity
{
    [Key]
    [Column("HOTEL_ID")]
    public int Id { get; set; }

    [Column("HOTEL_NAME")]
    public string? HotelName { get; set; }

    #region relationships

    public ICollection<RoomEntity> Rooms { get; set; } = [];

    #endregion relationships
}
