# Hotel Booking API 
## Overview
The Hotel Booking API handles the booking of hotel rooms in multiple hotels. The API considers 6 hotel rooms per hotel, each either a single (1), double (2) or deluxe (3) rooms. The API allows you to check availability of rooms for the number of guests and check-in / check-out dates. The API then subsequently allows you to book available rooms, by returning a unique booking ID. You can then retreive your booking details using these IDs.

## How to Access the API
### Deployment URLs
Test instance deployed via Azure Web Apps service. Base URL: https://hotelbookingtm-e2bvhjbhh0e4a9c2.uksouth-01.azurewebsites.net/

Swagger is enabled for non-production instances of the API: https://hotelbookingtm-e2bvhjbhh0e4a9c2.uksouth-01.azurewebsites.net/swagger/index.html

Swagger JSON / documentation: https://hotelbookingtm-e2bvhjbhh0e4a9c2.uksouth-01.azurewebsites.net/swagger/v1/swagger.json

### Authentication
No authentication is required for this API.

### Endpoints
Controllers:
- Bookings: Get and create bookings 
- RoomAvailability: Get available rooms based on dates and number of people
- Hotels: Get all hotels or get hotels by search criteria (containing room information)
- TestData: Allows you to reset and seed data (for testing purposes only). Please make sure to reset the database before seeding.

## Build Information
### Tech Stack
- Database: Oracle Cloud Instance Database (relational)
- Programming Language: C#
- Framework: e.g., ASP.NET (.NET8.0)
- Cloud Provider: Azure
- Deployment: Deployed via workflow form GitHub to Azure Web Applications

### Contact Information
Please use the contact details below for any queries
- Project Maintainer: Tarun Mistry
- Email: tarunmistry22@gmail.com