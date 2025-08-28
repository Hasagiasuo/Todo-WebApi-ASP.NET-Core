# ASP.NET Core Web API Project

Цей проєкт реалізує **CRUD функціонал** через **ASP.NET Core Web API** з багатошаровою архітектурою.  

## Основні особливості

- ✅ **CRUD операції** для роботи з даними
- ✅ **IDisposable** для DbContext для правильного управління ресурсами  
- ✅ **DTO та AutoMapper** для мапінгу між моделями і об'єктами передачі даних  
- ✅ **Data Annotations та FluentValidation** для валідації даних  
- ✅ **Swagger / OpenAPI** для автоматичної генерації документації API  
- ✅ **LINQ** для сортування та фільтрації даних  
- ✅ **Пагінація та сортування** на рівні API  

## Архітектура

Проєкт реалізований у багатошаровому підході:  

Solution/
├─ Domain/ # Моделі та бізнес-логіка
├─ Application/ # Сервіси, DTO, AutoMapper профілі
├─ Infrastructure/ # Репозиторії, DBContext, EF Core
└─ WebApi/ # Контролери, конфігурація API, Swagger

## Запуск

1. Клонувати репозиторій:  
```bash
git clone <repo-url>
dotnet restore
dotnet build
dotnet run --project WebApi
http://localhost:<port>/swagger
```

Технології
- C# / .NET 7+
- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- FluentValidation
- Swagger/OpenAPI
