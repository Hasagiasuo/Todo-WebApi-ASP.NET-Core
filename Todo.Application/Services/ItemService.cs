using Todo.Domain.Repositories;
using AutoMapper;
using Todo.Application.DTO;
using Todo.Domain.Models;

namespace Todo.Application.Services;

public class ItemService(IItemReposrtory itemRepository, IUserRepository userRepository, IMapper mapper)
{
  private readonly IMapper _mapper = mapper;
  private readonly IItemReposrtory _itemRepository = itemRepository;
  private readonly IUserRepository _userRepository = userRepository;

  public async Task<bool> CreateItemAsync(ItemCreate dto)
  {
    Item item = _mapper.Map<Item>(dto);
    User? user = await _userRepository.GetByUsernameAsync(dto.Username);
    if (user == null) return false;
    item.User = user;
    if (await _itemRepository.ExistsForUserAsync(dto.Title, dto.Username)) return false;
    return await _itemRepository.AddAsync(item);
  }

  public async Task<ItemResponce?> GetItemAsync(string title, string username)
  {
    Item? item = await _itemRepository.GetByTitleUsernameAsync(title, username);
    return item == null ? null : _mapper.Map<ItemResponce>(item);
  }
  public async Task<bool> UpdateItemAsync(ItemUpdate dto)
  {
    return await _itemRepository.UpdateCompletedTimeAsync(dto.Title, dto.Username, dto.NewCompleteDate) &&
           await _itemRepository.UpdateIsCompletedAsync(dto.Title, dto.Username, dto.NewIsCompleted) &&
           await _itemRepository.UpdateTitleAsync(dto.Title, dto.Username, dto.NewTitle);
  }
  public async Task<ICollection<Item>> GetAllAsync()
  {
    return await _itemRepository.GetAllAsync();  
  }

  public async Task<bool> CompleteItemByTitleAsync(ItemCompleteNow dto)
  {
    if (!await _itemRepository.ExistsForUserAsync(dto.Title, dto.Username)) return false;
    return await _itemRepository.UpdateCompletedTimeAsync(dto.Title, dto.Username, DateTime.Now) &&
      await _itemRepository.UpdateIsCompletedAsync(dto.Title, dto.Username, true);
  }

  public async Task<ICollection<Item>> GetForPageAsync(int page, int pageSize, string username)
  {
    return await _itemRepository.GetByPageAsync(page, pageSize, username);
  }

  public async Task<ICollection<Item>> GetByDayAsync(int day, string username)
  {
    return await _itemRepository.GetCompletedByDayAsync(day, username);
  }
}