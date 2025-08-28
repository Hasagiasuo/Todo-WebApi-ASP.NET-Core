using System.Text.Json.Serialization;

namespace Todo.Domain.Models;

public class User
{
	public Guid Id { get; set; }	
	public required string Username { get; set; }
	public required string Token { get; set; }
  [JsonIgnore]
	public ICollection<Item> Items { get; set; } = [];
}