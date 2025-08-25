using HotelBookingAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HotelBookingAPI.Data;

internal class HotelBookingDbContext : DbContext
{
    private readonly DatabaseServiceOptions? _databaseServiceOptions;

    public HotelBookingDbContext(IOptions<DatabaseServiceOptions> databaseServiceOptions)
    {
        _databaseServiceOptions = databaseServiceOptions.Value;
    }

    public HotelBookingDbContext(DbContextOptionsBuilder builder) : base(builder.Options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_databaseServiceOptions != null && _databaseServiceOptions.AreServiceOptionsValid)
        {
            optionsBuilder.UseOracle(_databaseServiceOptions.ConnectionString);
        }

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HotelEntity>(hotelEntity =>
        {
            hotelEntity.HasKey(hotel => hotel.Id);

            hotelEntity.HasMany(hotel => hotel.Rooms).WithOne(room => room.Hotel)
                    .HasPrincipalKey(hotel => hotel.Id)
                    .HasForeignKey(room => room.HotelId);
        });

        modelBuilder.Entity<RoomEntity>(roomEntity =>
        {
            roomEntity.HasKey(room => room.Id);

            roomEntity.HasOne(room => room.Hotel).WithMany(hotel => hotel.Rooms)
                    .HasForeignKey(room => room.HotelId);

            roomEntity.HasMany(room => room.Bookings).WithOne(booking => booking.Room)
                    .HasPrincipalKey(room => room.Id)
                    .HasForeignKey(booking => booking.RoomId);
        });

        modelBuilder.Entity<BookingEntity>(bookingEntity =>
        {
            bookingEntity.HasKey(booking => booking.BookingId);

            bookingEntity.HasOne(booking => booking.Room).WithMany(hotel => hotel.Bookings)
                    .HasForeignKey(room => room.RoomId);
        });
    }

    internal virtual DbSet<HotelEntity> Hotels { get; set; } = null!;
    internal virtual DbSet<RoomEntity> Rooms { get; set; } = null!;
    internal virtual DbSet<BookingEntity> Bookings { get; set; } = null!;
}