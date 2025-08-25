-- User that owns database objects for the hotel booking API 
CREATE USER hotel_booking IDENTIFIED BY <pwd>;

-- Set memory limit for hotel_booking user
ALTER USER hotel_booking QUOTA 50m on USERS;