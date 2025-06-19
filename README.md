# CateringService

A catering service management web application developed as part of a Year 2 university module, using ASP.NET Core. The solution is split into two main projects: a backend Web API (`ThAmCo.Catering`) and a frontend Razor Pages web app (`Catering.Web`). The application demonstrates modern .NET development practices, including RESTful APIs, Entity Framework Core, and clean separation of concerns.

## Features

- **Menu Management:** Create, read, update, and delete menus and associated food items.
- **Food Booking:** Book catering for events, specifying menu and number of guests.
- **Database Integration:** Utilises Entity Framework Core with Sqlite for data persistence.
- **RESTful API:** Backend controllers expose endpoints for managing catering data.
- **Swagger/OpenAPI:** API documentation and exploration (enabled in development).
- **Frontend:** Razor Pages web application with Bootstrap styling.
- **Separation of Concerns:** Clean split between backend API and frontend.

## Technologies Used

- ASP.NET Core 6
- Entity Framework Core (Sqlite)
- Razor Pages
- Swagger (Swashbuckle)
- Bootstrap

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- (Optional) Visual Studio 2022 or later

### Running the Backend API

1. Open a terminal in the `ThAmCo.Catering` project directory.
2. Build and run the API:
   ```bash
   dotnet run
   ```
3. The API will be available at `https://localhost:5001` by default.
4. Swagger UI for API testing will be available at `https://localhost:5001/swagger` in development mode.

### Running the Frontend

1. Open a terminal in the `Catering.Web` project directory.
2. Build and run the web app:
   ```bash
   dotnet run
   ```
3. Access the site in your browser at `https://localhost:5002` (or as indicated in the terminal).

## Project Structure

- `ThAmCo.Catering/` - Backend Web API (controllers, data models, EF Core context).
- `Catering.Web/` - Frontend Razor Pages app (user interface).
- `CateringContext.cs` - Entity Framework Core context, configures relationships and seeds sample data.
- `Controllers/` - API controllers for menus and food bookings.

## Educational Value

This project demonstrates:
- Building RESTful APIs and frontend apps with ASP.NET Core.
- Using Entity Framework Core for ORM and data seeding.
- Applying separation of concerns and dependency injection.
- Integrating Swagger for API documentation.

## Author

- James Fothergill

## Licence

This project is for educational purposes.

