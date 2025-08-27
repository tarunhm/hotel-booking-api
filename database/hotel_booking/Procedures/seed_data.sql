CREATE OR REPLACE PROCEDURE hotel_booking.seed_data
AS
BEGIN
    INSERT INTO hotel_booking.hotels (hotel_id, hotel_name) VALUES (1,'Grand Royal Hotel');
    INSERT INTO hotel_booking.hotels (hotel_id, hotel_name) VALUES (2,'The Budget Inn');
    INSERT INTO hotel_booking.hotels (hotel_id, hotel_name) VALUES (3,'Townhouse Hotel');
    INSERT INTO hotel_booking.hotels (hotel_id, hotel_name) VALUES (4,'Central Spa Hotel');

    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (11, 1, 'Deluxe', 3);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (12, 1, 'Deluxe', 3);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (13, 1, 'Deluxe', 3);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (14, 1, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (15, 1, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (16, 1, 'Double', 2);

    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (21, 2, 'Single', 1);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (22, 2, 'Deluxe', 3);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (23, 2, 'Deluxe', 3);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (24, 2, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (25, 2, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (26, 2, 'Single', 1);
    
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (31, 3, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (32, 3, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (33, 3, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (34, 3, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (35, 3, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (36, 3, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (41, 4, 'Single', 1);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (42, 4, 'Single', 1);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (43, 4, 'Deluxe', 3);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (44, 4, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (45, 4, 'Double', 2);
    INSERT INTO hotel_booking.rooms (room_id, hotel_id, room_type, room_capacity) VALUES (46, 4, 'Double', 2);

END;
/