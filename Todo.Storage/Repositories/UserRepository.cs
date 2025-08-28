using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Todo.Storage.Context;

namespace Todo.Storage.Repositories;

public class UserRepository(TodoDbContext context) : IUserRepository
{
  private readonly TodoDbContext _context = context;
  
  public async Task<bool> AddAsync(User entity)
  {
    _context.Users.Add(entity);
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> RemoveAsync(User user)
  {
    _context.Users.Remove(user);
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> UpdateAsync(User user)
  {
    User? tmp =  _context.Users
      .SingleOrDefault(x => x.Id == user.Id);
    if (tmp == null) return false;
    tmp = user;
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<User?> GetAsync(Guid id)
  {
    return await _context.Users
      .Include(i => i.Items)
      .FirstOrDefaultAsync(x => x.Id == id);
  }
  public async Task<bool> ExistsAsync(string username)
  {
    return await _context.Users.AnyAsync(x => x.Username == username); 
  }

  public async Task<User?> GetByUsernameAsync(string username)
  {
    return await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
  }

  public async Task<ICollection<User>> GetAllAsync()
  {
    return await _context.Users
      .Include(i => i.Items) 
      .ToListAsync();
  }
}