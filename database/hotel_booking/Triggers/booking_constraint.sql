-- Trigger for constraint to avoid double booking rooms
CREATE OR REPLACE TRIGGER hotel_booking.check_booking_constraints
BEFORE INSERT ON hotel_booking.bookings
FOR EACH ROW
DECLARE
    conflicting_count INTEGER;
BEGIN
    -- Check for bookings with the same room_id and check_in_date
    SELECT COUNT(*)
    INTO conflicting_count
    FROM hotel_booking.bookings
    WHERE room_id = :NEW.room_id
      AND check_in_date = :NEW.check_in_date;

    IF conflicting_count > 0 THEN
        RAISE_APPLICATION_ERROR(-20001, 'A booking already exists for this room on the same check-in date.');
    END IF;

    -- Check for past bookings
    SELECT COUNT(*)
    INTO conflicting_count
    FROM hotel_booking.bookings
    WHERE room_id = :NEW.room_id
      AND check_in_date < :NEW.check_in_date
      AND check_out_date - check_in_date > :NEW.check_in_date - check_in_date;

    IF conflicting_count > 0 THEN
        RAISE_APPLICATION_ERROR(-20002, 'Room unavailable due to existing booking.');
    END IF;

    -- Check for future bookings
    SELECT COUNT(*)
    INTO conflicting_count
    FROM hotel_booking.bookings
    WHERE room_id = :NEW.room_id
      AND check_in_date > :NEW.check_in_date
      AND :NEW.check_out_date - :NEW.check_in_date > check_in_date - :NEW.check_in_date;

    IF conflicting_count > 0 THEN
        RAISE_APPLICATION_ERROR(-20003, 'Room unavailable due to existing booking.');
    END IF;
END;
