using HotelBookingAPI.Data.Entities;
using HotelBookingAPI.Data.Mappers;
using HotelBookingAPI.Data.Repositories.Interface;
using HotelBookingAPI.Data.Services.Interface;
using HotelBookingAPI.Shared.Models;

namespace HotelBookingAPI.Data.Services;

public class BookingService : IBookingService
{
    public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository)
    {
        _bookingRepository = bookingRepository;
        _roomRepository = roomRepository;
    }

    private IBookingRepository _bookingRepository { get; }
    public IRoomRepository _roomRepository { get; }

    public async Task<BookingModel?> GetById(int id)
    {
        var booking = await _bookingRepository.GetBooking(id);
        if (booking == null) { return null; }

        return BookingMapper.MapEntityToModel(booking);
    }

    public async Task<int> CreateBooking(BookingRequestModel bookingRequest)
    {
        // Check room exists
        var room = _roomRepository.GetByID(bookingRequest.RoomId)
            ?? throw new InvalidOperationException($"Room with ID {bookingRequest.RoomId} does not exist.");

        // Check room is available
        if (IsRoomAvailable(room.Bookings, bookingRequest.CheckInDate, bookingRequest.Nights))
        {
            var bookingEntity = BookingMapper.MapRequestModelToEntity(bookingRequest);

            return await _bookingRepository.CreateBookingEntity(bookingEntity);
        }

        throw new InvalidOperationException($"Room with ID {bookingRequest.RoomId} is not available for check in on {bookingRequest.CheckInDate} for {bookingRequest.Nights} nights.");
    }

    public IList<RoomHotelModel> GetAvailableRooms(int people, DateOnly checkInDate, int duration)
    {
        var rooms = _roomRepository.GetByCapacity(people);
        if (!rooms.Any()) { return []; }

        var availableRooms = rooms.Where(room => IsRoomAvailable(room.Bookings, checkInDate, duration));

        return availableRooms.Select(RoomMapper.MapEntityToHotelModel).ToList();
    }

    private static bool IsRoomAvailable(ICollection<BookingEntity> bookings, DateOnly checkInDate, int newBookingDuration)
    {
        if (!bookings.Any()) { return true; }
        var overlapBookings = bookings.Where(b => BookingOverlaps(DateOnly.FromDateTime(b.CheckInDate), 
                                             DateOnly.FromDateTime(b.CheckOutDate),
                                             checkInDate,
                                             newBookingDuration));

        return !overlapBookings.Any();
    }

    private static bool BookingOverlaps(DateOnly checkInDate, DateOnly checkOutDate, DateOnly newBookingCheckInDate, int newBookingDuration)
    {
        int daysBetweenCheckIn = newBookingCheckInDate.DayNumber - checkInDate.DayNumber;

        // Check in of booking is after proposed booking
        if (daysBetweenCheckIn < 0) 
        {
            // if proposed stay is shorter than duration then no overlap
            // if duration is longer than days between check in, then overlap
            // If duration is the same as days between check in then no overlap
            return newBookingDuration > Math.Abs(daysBetweenCheckIn);
        }

        // Check in of booking is before the proposed booking
        if (daysBetweenCheckIn > 0) 
        {
            int bookingDuration = checkOutDate.DayNumber - checkInDate.DayNumber;

            // if existing duration is shorter than difference then no overlap
            // if existing duration is longer than days between check in, then overlap
            // If existing duration is the same as days between check in then no overlap
            return bookingDuration > daysBetweenCheckIn;
        }
        
        // If booking starts on same date
        return true;
    }
}
