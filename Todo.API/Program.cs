using Todo.Domain.Models;
using Todo.Application.Services;
using FluentValidation;
using Todo.Application.DTO;
using Todo.Application.Validators.UserValidators;
using Todo.Application.Validators.ItemValidators;
using Todo.Domain.Repositories;
using Todo.Storage.Context;
using Todo.Storage.Repositories;
using Microsoft.EntityFrameworkCore;
using Todo.Application.Mapping.Profiles;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDbContext>(options => options.UseSqlite("Data source=data.db"));

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<UserCreate>, UserCreateValidator>();
builder.Services.AddScoped<IValidator<Item>, ItemValidator>();

// Adding repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IItemReposrtory, ItemRepository>();

// Adding services
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ItemService>();

// Adding mappers
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ItemProfile).Assembly);

WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
	app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();