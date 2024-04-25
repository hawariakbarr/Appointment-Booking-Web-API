# Appointment Booking System

## Description
The Appointment Booking System is a .NET Web API designed to help agencies manage and schedule appointments efficiently. It allows for booking appointments, checking availability, managing configurations such as holidays and appointment limitations, and viewing appointments by date.

## Features
- **Booking Appointments**: Users can book appointments specifying the desired date and customer details.
- **Viewing Appointments**: Users can view all appointments for a specific day.
- **Managing Agency Configuration**: Agency can add new configuration and can update settings to specify holidays and maximum appointments per day.

## Technologies Used
- **.NET 8**: Target framework for the API.
- **Entity Framework Core**: For data access and management.
- **SQLite**: Databases used for storing appointment and configuration data.
- **Swagger**: For API documentation and testing.
- **Azure App Service**: Recommended for hosting the API.

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022 or later
- SQLite, depending on your setup preferences

### Installation
1. **Clone the repository**
   ```sh
   git clone https://github.com/yourgithubusername/Appointment-Booking-Web-API.git

2. **Navigate to the project directory**
   ```sh
   cd Appointment Booking Web API

3. **Restore the .NET packages**
   ```sh
   dotnet restore

4. **Update the database**
   ```sh
   dotnet ef database update --project AppointmentBooking.Data

5. **Run the application**
   ```sh
   dotnet run --project AppointmentBooking.API

### API Endpoints
```
POST    /api/appointment/book: Book a new appointment.
GET     /api/appointment/appointment-by-date: Retrieve appointments by date.
GET     /api/agencyconfiguration: Get current configuration settings.
PUT     /api/agencyconfiguration/update-agency-configuration: Update configuration settings.
POST    /api/agencyconfiguration/add-agency-configuration: Add new configuration settings.
```

