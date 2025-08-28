using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTO;
using Todo.Application.Services;
using Todo.Domain.Models;

namespace Todo.API.Controllers;

[ApiController]
[Route("users")]
public class UserController(UserService userService) : ControllerBase
{
  private readonly UserService _userService = userService;
  [HttpGet]
  public async Task<IActionResult> GetAllUsers()
  {
    ICollection<User> cols = await _userService.GetAllUsersAsync();
    return Ok(cols.ToList());
  }
  [HttpPost]
  public async Task<IActionResult> CreateUser([FromBody] UserRequest dto)
  {
    return await _userService.CreateUser(dto) ? Ok() : BadRequest();  
  }
}