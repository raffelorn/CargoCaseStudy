
# TMS Management System

## Overview

This is a TMS (Transportation Management System) application designed to manage shipping selection rules and cargo definitions. It features a Blazor front-end for CRUD operations and a .NET Core 6 backend with a PostgreSQL database. The application also includes a REST API to fetch shipping rules based on specific input parameters.

## Technologies Used

- **Backend Framework**: .NET Core 6
- **Front-end Framework**: Blazor
- **Database**: PostgreSQL
- **ORM**: Entity Framework Core

## Features

### Blazor UI
- Manage records in the `ShippingSelectionRules` table with add, edit, delete, and list functionality.
- Manage records in the `CargoDefinitions` table with similar functionality.
- Pagination is implemented for listing records efficiently.

### API Endpoint
- Provides a REST API endpoint to fetch matching shipping rules based on city, district, and weight.
- Only returns results where:
  - The city and district match a rule in the `ShippingSelectionRules` table.
  - The weight is within the MinWeight and MaxWeight range in the `CargoDefinitions` table for the relevant cargo.

### Business Logic
- The API ensures that both `City` and `District` match a rule, and the weight falls within the correct range, before returning results.

### Technical Requirements
- Proper validation is enforced on both the Blazor UI and API.
- Exception handling for database operations to maintain data integrity.
- The project follows best practices for clean code and maintainability.

## Database Schema

The project contains two primary tables:

### `ShippingSelectionRules`
| Column      | Type   | Description                  |
|-------------|--------|------------------------------|
| `Id`        | int    | Primary Key                  |
| `City`      | string | Name of the city             |
| `District`  | string | Name of the district         |
| `OrderNo`   | int    | Order number for the rule    |
| `Cargo`     | string | Cargo identifier             |

### `CargoDefinitions`
| Column       | Type   | Description                        |
|--------------|--------|------------------------------------|
| `Id`         | int    | Primary Key                        |
| `Cargo`      | string | Cargo identifier                   |
| `MinWeight`  | float  | Minimum weight for the cargo type  |
| `MaxWeight`  | float  | Maximum weight for the cargo type  |

## Setup Instructions

### Prerequisites

- .NET Core SDK 6.0 or higher
- PostgreSQL database

### Getting Started

1. **Clone the Repository**
   ```bash
   git clone <repository-url>
   cd TMS-Management-System
   ```

2. **Configure the Database**
   - Create a PostgreSQL database.
   - Update the connection string in `appsettings.json`:
     ```json
     "ConnectionStrings": {
         "DefaultConnection": "Host=localhost;Database=TMSDB;Username=yourusername;Password=yourpassword"
     }
     ```

3. **Run Migrations**
   - Apply migrations to create the database tables:
     ```bash
     dotnet ef database update
     ```

4. **Run the Application**
   - Start the application using the following command:
     ```bash
     dotnet run
     ```
   - The Blazor front-end will open in the default browser at `https://localhost:5001`.

5. **Testing the API**
   - Use an API client like Postman to test the API endpoint:
     ```http
     POST https://localhost:5001/api/shipping-rules
     ```
     - **Body**:
       ```json
       {
         "city": "Istanbul",
         "district": "Sariyer",
         "weight": 3
       }
       ```

## Project Structure

- **Controllers**: Contains API controllers for the backend.
- **Pages**: Contains Blazor pages for managing `ShippingSelectionRules` and `CargoDefinitions`.
- **Models**: Defines entity models and validation attributes.
- **Data**: Includes the `ApplicationDbContext` for database context and data access logic.

## Additional Notes

- Ensure proper validation and exception handling in both the Blazor UI and API.
- Follow best practices for clean code and maintainable structure.
