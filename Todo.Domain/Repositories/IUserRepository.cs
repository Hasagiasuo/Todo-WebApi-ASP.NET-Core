namespace Todo.Domain.Repositories;
using Models;

public interface IUserRepository : IBaseRepository<User>
{
  Task<bool> ExistsAsync(string username);
  Task<User?> GetByUsernameAsync(string username);
}