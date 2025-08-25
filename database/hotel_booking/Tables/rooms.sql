CREATE TABLE hotel_booking.rooms (
    room_id NUMBER PRIMARY KEY,
    hotel_id NUMBER,
    room_type VARCHAR2(10),
    room_capacity NUMBER(2) NOT NULL,
    CONSTRAINT fk_hotel FOREIGN KEY (hotel_id) REFERENCES hotel_booking.hotels(hotel_id) ON DELETE CASCADE -- Cascade delete rooms when a hotel is deleted
);

COMMENT ON TABLE hotel_booking.rooms IS 'Table of rooms existing in hotels.';

COMMENT ON COLUMN hotel_booking.rooms.room_id IS 'Unique room identifier (Primary Key).';
COMMENT ON COLUMN hotel_booking.rooms.hotel_id IS 'Hotel identifier where the room exists (Foreign Key to hotel_bookings.hotels.hotel_id).';
COMMENT ON COLUMN hotel_booking.rooms.room_type IS 'Room type: single, double, or deluxe.';
COMMENT ON COLUMN hotel_booking.rooms.room_capacity IS 'Capacity of room (defined by room type).';