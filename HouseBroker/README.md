# House Broker Application

## Tech Stack
- .NET 8 Web API
- MSSQL
- Entity Framework Core
- Clean Architecture

## Setup

1. Clone repo
2. Update connection string in src/HouseBroker.API/appsettings.json
3. Run migration:
   dotnet ef database update
4. Run project:
   dotnet run

## Features
- Authentication (Identity)
- PropertyListing CRUD
- Commission Engine
- Search & Filters
- Caching
- Unit Tests