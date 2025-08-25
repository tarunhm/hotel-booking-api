-- Allow service account to create session
GRANT CREATE SESSION TO hotel_booking_svc;

-- Grants to db objects
GRANT READ ON hotel_booking.hotels TO hotel_booking_svc;
GRANT READ ON hotel_booking.rooms TO hotel_booking_svc;
GRANT CREATE, DELETE, UPDATE, READ ON hotel_booking.bookings TO hotel_booking_svc;