# ECommerce API

ASP.NET Core web API for managing products and categories in an e-commerce application.

## Prerequisites

- .NET 7.0 SDK (or higher)
- Visual Studio 2022, VS Code, or any compatible editor

## Setup

1. Clone the repository
2. Open the project in Visual Studio or VS Code
3. Restore NuGet packages:
   ```bash
   dotnet restore ECommerceAPI.csproj
   ```

## Database

The API uses Entity Framework Core with **SQLite** for development. The database will be created automatically on first startup in the `ECommerceDB.db` file.

### Connection String

The default connection string uses SQLite:
```
Data Source=ECommerceDB.db
```

> **Note**: To use SQL Server in production, modify the NuGet package and connection string in `appsettings.json`.

## Getting Started

```bash
dotnet run --project ECommerceAPI.csproj
```

The API will be available at `http://localhost:5000` (or the configured port).

## Testing the API

### Option 1: Swagger UI (Recommended)

**Swagger is already installed and configured!** No additional installation needed.

1. Start the application:
   ```bash
   dotnet run --project ECommerceAPI.csproj
   ```

2. Open your browser and navigate to:
   ```
   http://localhost:5000/swagger
   ```

3. You will see an interactive interface with all available endpoints. You can:
   - View all endpoints (GET, POST, DELETE)
   - Test each endpoint directly from the browser
   - View data models (DTOs)
   - Execute requests and see responses

### Option 2: cURL or Postman

You can also test the API with:
- **cURL** (command line)
- **Postman** (desktop application)
- **Thunder Client** (VS Code extension)
- Your frontend application (React/Angular)

### cURL Examples

```bash
# Get all products
curl http://localhost:5000/api/products

# Get a product by ID
curl http://localhost:5000/api/products/1

# Create a product
curl -X POST http://localhost:5000/api/products \
  -H "Content-Type: application/json" \
  -d '{"name": "New Product", "description": "Description", "price": 199, "image": "/images/test.png", "categories": [1]}'
```

## Endpoints

### Products

- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get a product by ID
- `GET /api/products?slug={slug}` - Get a product by slug
- `POST /api/products` - Create a new product
- `DELETE /api/products/{id}` - Delete a product

### Categories

- `GET /api/categories` - Get all categories with their products
- `GET /api/categories/{id}` - Get a category by ID
- `GET /api/categories?slug={slug}` - Get a category by slug
- `POST /api/categories` - Create a new category
- `DELETE /api/categories/{id}` - Delete a category

## Usage Examples

### Create a Product

```json
POST /api/products
{
  "name": "T-Shirt",
  "description": "Lorem ipsum dolor",
  "price": 199,
  "image": "/images/t-shirt.png",
  "categories": [1]
}
```

### Create a Category

```json
POST /api/categories
{
  "name": "T-Shirts",
  "image": "/images/t-shirt.png"
}
```

## Features

- Automatic URL-slug generation
- Many-to-many relationships between products and categories
- Data validation
- Appropriate HTTP error handling
- Test data included

## Project Structure

```
ECommerceAPI/
├── Controllers/          # API Controllers
├── Data/                # Entity Framework Context
├── DTOs/                # Data Transfer Objects
├── Models/              # Data Models
├── Services/            # Utility Services
├── Program.cs           # Application Entry Point
└── appsettings.json     # Configuration
```
