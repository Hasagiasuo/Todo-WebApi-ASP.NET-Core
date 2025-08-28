using Todo.Application.DTO;
using Todo.Domain.Models;
using Todo.Domain.Repositories;
using AutoMapper;
using Todo.Application.Privacy;

namespace Todo.Application.Services;

public class UserService(IMapper mapper, IUserRepository userRepository, IItemReposrtory itemRepository)
{
  private readonly IUserRepository _userRepository = userRepository;
	private readonly IMapper _mapper = mapper;
  public async Task<bool> CreateUser(UserRequest dto)
  {
    if(await _userRepository.ExistsAsync(dto.Username)) return false;
    string token = await TokenGenerator.GenerateToken(dto.Username);
    UserCreate newDto = new(dto.Username, token)
    {
      Username = dto.Username,
      Token = token 
    };
    return await _userRepository.AddAsync(_mapper.Map<User>(newDto));
  }
  public async Task<ICollection<User>> GetAllUsersAsync()
  {
    return await _userRepository.GetAllAsync();
  }
}