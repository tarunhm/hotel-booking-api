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
        modelBuilder.Entity<HotelEntity>()
            .HasKey(x => x.Id);
    }

    internal virtual DbSet<HotelEntity> Hotels { get; set; } = null!;
    internal virtual DbSet<RoomEntity> Rooms { get; set; } = null!;
    internal virtual DbSet<BookingEntity> Bookings { get; set; } = null!;
}