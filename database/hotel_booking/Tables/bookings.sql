CREATE TABLE hotel_booking.bookings (
    booking_id NUMBER PRIMARY KEY,
    room_id NUMBER,
    check_in_date DATE NOT NULL, 
    check_out_date DATE NOT NULL,
    booking_username VARCHAR2(50),
    CONSTRAINT fk_room FOREIGN KEY (room_id) REFERENCES hotel_booking.rooms(room_id) 
);

COMMENT ON TABLE hotel_booking.bookings IS 'Table of booking existing for each room in hotels with check in and out dates.';

COMMENT ON COLUMN hotel_booking.bookings.booking_id IS 'Unique booking identifier (Primary Key).';
COMMENT ON COLUMN hotel_booking.bookings.room_id IS 'Room identifier for the booking (Foreign Key to hotel_bookings.rooms.room_id).';
COMMENT ON COLUMN hotel_booking.bookings.check_in_date IS 'Check in date for booking.';
COMMENT ON COLUMN hotel_booking.bookings.check_out_date IS 'Check out date for booking.';
COMMENT ON COLUMN hotel_booking.bookings.booking_username IS 'Identifier of booking party (optional).';

-- Trigger to auto-generate booking_id (primary key)
CREATE OR REPLACE TRIGGER hotel_booking.trg_booking_id
BEFORE INSERT ON hotel_booking.bookings
FOR EACH ROW
BEGIN
    SELECT hotel_booking.booking_id_seq.NEXTVAL INTO :NEW.booking_id FROM dual;
END;
/