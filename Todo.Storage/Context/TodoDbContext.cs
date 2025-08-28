using Microsoft.EntityFrameworkCore;
using Todo.Storage.Configurations;
using Todo.Domain.Models;

namespace Todo.Storage.Context;

public class TodoDbContext(DbContextOptions<TodoDbContext> options) : DbContext(options)
{
  public DbSet<User> Users { get; set; } 
  public DbSet<Item> Items { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new UserConfiguration());
    modelBuilder.ApplyConfiguration(new ItemConfiguration());
  }
}