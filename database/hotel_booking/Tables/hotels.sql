CREATE TABLE hotel_booking.hotels ( 
hotel_id   NUMBER PRIMARY KEY, 
hotel_name VARCHAR2 (200) 
);

COMMENT ON TABLE hotel_booking.hotels IS 'Table of hotels with bookable rooms.';

COMMENT ON COLUMN hotel_booking.hotels.hotel_id IS 'Unique hotel identifier (Primary Key).';
COMMENT ON COLUMN hotel_booking.hotels.hotel_name IS 'Name of hotel.';