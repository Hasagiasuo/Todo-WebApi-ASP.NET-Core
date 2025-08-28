using AutoMapper;
using Todo.Domain.Models;

namespace Todo.Application.DTO;

public class UserCreate(string username, string token)
{
  public required string Username { get; set; } = username;
  public required string Token { get; set; } = token;
}

public class UserRequest(string username) 
{
  public required string Username { get; set; } = username;
}