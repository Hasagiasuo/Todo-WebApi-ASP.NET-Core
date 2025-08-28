using System.Security.Cryptography;
using System.Text;

namespace Todo.Application.Privacy;

public static class TokenGenerator
{
  public static async Task<string> GenerateToken(string username)
  {
    byte[] bytes = Encoding.UTF8.GetBytes(username + DateTime.UtcNow.Ticks);
    byte[] hash = SHA256.HashData(bytes);
    return await Task.FromResult(Convert.ToBase64String(hash)); 
  }
}