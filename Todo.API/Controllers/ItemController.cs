using Microsoft.AspNetCore.Mvc;
using Todo.Application.DTO;
using Todo.Application.Services;

namespace Todo.API.Controllers;

[ApiController]
[Route("item")]
public class ItemController(ItemService itemService) : ControllerBase
{
  private readonly ItemService _itemService = itemService;
  
  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    return Ok(await _itemService.GetAllAsync());
  }

  [HttpPost]
  [Route("add")]
  public async Task<IActionResult> CreateItem([FromBody] ItemCreate dto)
  {
    return await _itemService.CreateItemAsync(dto) ? Ok() : BadRequest();
  }

  [HttpPost]
  [Route("complete")] 
  public async Task<IActionResult> CompleteItem([FromBody] ItemCompleteNow dto)
  {
    return await _itemService.CompleteItemByTitleAsync(dto) ?  Ok() : BadRequest();  
  }

  [HttpPost]
  [Route("page/{page:int}/{pageSize:int}/{username}")]
  public async Task<IActionResult> PageItems(int page, int pageSize, string username)
  {
    return Ok(await _itemService.GetForPageAsync(page, pageSize, username));
  }

  [HttpPost]
  [Route("complete/{day:int}/{username}")]
  public async Task<IActionResult> CompleteDayItem(int day, string username)
  {
    return Ok(await _itemService.GetByDayAsync(day, username));
  }
}