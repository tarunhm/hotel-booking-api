CREATE OR REPLACE PROCEDURE hotel_booking.reset_data()
AS
    DELETE * FROM hotel_booking.bookings;

    -- Will also delete rooms via cascade delete
    DELETE * FROM hotel_booking.hotels;
END;
/