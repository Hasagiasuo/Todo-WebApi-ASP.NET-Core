using Todo.Domain.Models;

namespace Todo.Domain.Repositories;

public interface IBaseRepository<T>
{
  Task<bool> AddAsync(T entity);
  Task<bool> RemoveAsync(T entity);
  Task<bool> UpdateAsync(T entity);
  Task<T?> GetAsync(Guid id);
  Task<ICollection<T>> GetAllAsync();
}