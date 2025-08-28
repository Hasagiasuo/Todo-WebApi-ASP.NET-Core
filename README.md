# ASP.NET Core Web API Project

This project implements **CRUD functionality** through **ASP.NET Core Web API** with a multi-tier architecture.  

## Key features

- ✅ **CRUD operations** for working with data
- ✅ **IDisposable** for DbContext for proper resource management
- ✅ **DTO and AutoMapper** for mapping between models and data transfer objects
- ✅ **Data Annotations and FluentValidation** for data validation  
- ✅ **Swagger / OpenAPI** for automatic API documentation generation
- ✅ **LINQ** for sorting and filtering data
- ✅ **Pagination and sorting** at the API level

## Architecture

The project was implemented using a multi-layered approach:

Solution  
- Domain — Models and business logic  
- Application — Services, DTO, AutoMapper profiles  
- Infrastructure — Repositories, DBContext, EF Core  
- WebApi — Controllers, API configuration, Swagger

## Launch

1. Clone the repository:  
```bash
git clone <repo-url>
dotnet restore
dotnet build
dotnet run --project WebApi
http://localhost:<port>/swagger
```

Technologies
- C# / .NET 9
- ASP.NET Core Web API
- Entity Framework Core (SQLite)
- AutoMapper
- FluentValidation
- Swagger/OpenAPI

Translated with DeepL.com (free version)
