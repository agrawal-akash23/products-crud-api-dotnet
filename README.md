# Products CRUD Web API — ASP.NET Core

A RESTful Web API for managing products (Create, Read, Update, Delete) built using ASP.NET Core.

## Features
- Full CRUD operations for products
- Clean architecture using Services + Controllers
- Middleware pipeline (custom logging + exception handling)
- Dependency Injection (built-in DI container)
- Swagger UI for API testing

## Concepts covered
- ASP.NET Core request pipeline
- Middleware (custom + built-in)
- Dependency Injection (Scoped lifetime)
- Routing and Controllers
- HTTP verbs (GET, POST, PUT, DELETE)
- Swagger / OpenAPI
- In-memory data storage (no database)

## API Endpoints

| Method | Endpoint              | Description         |
|--------|----------------------|---------------------|
| GET    | /api/products        | Get all products    |
| GET    | /api/products/{id}   | Get product by ID   |
| POST   | /api/products        | Create new product  |
| PUT    | /api/products/{id}   | Update product      |
| DELETE | /api/products/{id}   | Delete product      |

## Sample Request (POST)
```json
{
  "name": "Phone",
  "category": "Electronics",
  "price": 25000,
  "stockQuantity": 5
}
