namespace Todo.Domain.Repositories;
using Models;

public interface IItemReposrtory : IBaseRepository<Item>
{
	Task<User?> GetOwnerAsync(Item item);
  Task<bool> ExistsForUserAsync(string title, string username);
  Task<Item?> GetByTitleUsernameAsync(string title, string username);
  Task<bool> UpdateIsCompletedAsync(string title, string username, bool isCompleted);
  Task<bool> UpdateCompletedTimeAsync(string title, string username, DateTime completedDate);
  Task<bool> UpdateTitleAsync(string title, string username, string newTitle);
  Task<ICollection<Item>> GetByPageAsync(int page, int pageSize, string username);
  Task<ICollection<Item>> GetCompletedByDayAsync(int day, string username);
}