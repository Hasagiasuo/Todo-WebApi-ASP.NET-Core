using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;
using Todo.Domain.Repositories;
using Todo.Storage.Context;

namespace Todo.Storage.Repositories;

public class ItemRepository(TodoDbContext context) : IItemReposrtory
{
  private readonly TodoDbContext _context = context;
  
  public async Task<bool> AddAsync(Item entity)
  {
    _context.Items.Add(entity);
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> RemoveAsync(Item entity)
  {
    _context.Items.Remove(entity);
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> UpdateAsync(Item entity)
  {
    Item? tmp = await _context.Items.FirstOrDefaultAsync(x => x.Id == entity.Id)!;  
    if (tmp == null) return false;  
    tmp = entity;
    return await _context.SaveChangesAsync() > 0;
  }
  public Task<Item?> GetAsync(Guid id)
  {
    return _context.Items
      .Include(u => u.User)
      .FirstOrDefaultAsync(x => x.Id == id)!;
  }
  public async Task<User?> GetOwnerAsync(Item item)
  {
    return await _context.Users.FirstOrDefaultAsync(x => x.Id == item.Id)!;
  }
  public async Task<bool> ExistsForUserAsync(string title, string username)
  {
    Item? tmp = await _context.Items
      .Include(tem => tem.User)
      .FirstOrDefaultAsync(x => x.Title == title);
    return tmp != null && tmp.User.Username == username;;
  }
  public async Task<ICollection<Item>> GetAllAsync()
  {
    return await _context.Items
      .Include(u => u.User) 
      .ToListAsync();
  }
  public async Task<Item?> GetByTitleUsernameAsync(string title, string username)
  {
    return await _context.Items
      .Include(tem => tem.User)
      .FirstOrDefaultAsync(x => x.Title == title && x.User.Username == username);
  }
  public async Task<bool> UpdateIsCompletedAsync(string title, string username, bool isCompleted)
  {
    Item? tmp = await _context.Items.FirstOrDefaultAsync(x => x.Title == title && x.User.Username == username);
    if (tmp == null) return false;
    tmp.IsCompleted = isCompleted;
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> UpdateCompletedTimeAsync(string title, string username, DateTime completedDate)
  {
    Item? tmp = await _context.Items.FirstOrDefaultAsync(x => x.Title == title && x.User.Username == username);
    if (tmp == null) return false;
    tmp.CompletedDate = completedDate;
    return await _context.SaveChangesAsync() > 0;
  }
  public async Task<bool> UpdateTitleAsync(string title, string username, string newTitle)
  {
    Item? tmp = await _context.Items.FirstOrDefaultAsync(x => x.Title == title && x.User.Username == username);
    if (tmp == null) return false;
    tmp.Title = newTitle;
    return await _context.SaveChangesAsync() > 0; 
  }

  public async Task<ICollection<Item>> GetByPageAsync(int page, int pageSize, string username)
  {
    IQueryable<Item> tmp = _context.Items
      .Include(u => u.User)
      .OrderBy(x => x.Created)
      .Where(x => x.User.Username == username)
      .Skip((page - 1) * pageSize)
      .Take(pageSize);
    return await tmp.ToListAsync();
  }

  public async Task<ICollection<Item>> GetCompletedByDayAsync(int day, string username)
  {
    DateTime baseDate = DateTime.Now;
    DateTime forSearch = new DateTime(baseDate.Year, baseDate.Month, day);
    DateTime start = forSearch.Date;       
    DateTime end = start.AddDays(1);      
    return await _context.Items
      .Include(u => u.User)
      .Where(x => x.CompleteDate >= start 
        && x.CompleteDate < end
        && x.User.Username == username)
      .ToListAsync();
  }
}