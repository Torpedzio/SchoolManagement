# School Management API

Backend API for managing a small music school.  
The system supports student enrollment, course management, payments, and scheduling, designed using Clean Architecture, CQRS, and Domain-Driven Design principles.

## Features
- Student management (create, daective, dashboard)
- Teacher management
- Course management with capacity limits
- Student enrollment to course
- Payment tracking and status management
- Student dashborard with aggregated data
- Global error handling with ProblemDetails

## Architecture
The projekt is build using Clean Architecture principles and CQRS pattern.

### Layers:
- **Domain** - business entities and core rules
- **Application** - use cases (commands & queries), validation, interfaces
- **Infrastructure** - EF Core, PostgreSQL, repositories
- **API** - HTTP layer, controllers, middleware

### Key architectural dacisions:
- CQRS with MediaR
- No direct dependency between Application and infrastructure
- Domain logic encapsulated inside entities
- Queries return DTOs instead of entities
- Global exception handling via middleware

## Technologies

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- MediaR
- FluentValidation
- Docker
- Swagger

## Example Use Cases

### Get student dashboard
Returns aggregated data for a student:
- active anrollments
- course details
- unpaid payments summary

`GET /api/students/{id}/dashboard`

### Get availabe courses
Returns courses with availabe slots based on enrollment count

`GET /api/courses/available`

## Error Handling
The API uses a gloal exception handling middleware thet maps domain exceptions to HTTP responses using the ProblemDetails standard.

Examples:
- `404 Not Found` - resource does not exist
- `409 Confilct` - business rule violation
- `400 Bad Request` - invalid input

## Running the project
1. Cofigure PostgreSQL conntection (local or Docker)
2. Run database migrations
3. Start the API
4. Open Swagger at `/swagger`

## Purpose of the project
This project was created to demonstrate:
- practical use of Clean Architecture
- CQRS and MediaR in real-world scenario
- separation of concerns
- designing backend APIs for frontend needs

## Possible Improvments
- Authentication and authorization
- Role-base access
- Integration tests
- Caching for read-heavy queries