using AutoMapper;
using Todo.Application.DTO;
using Todo.Domain.Models;

namespace Todo.Application.Mapping.Profiles;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<UserCreate, User>();
    CreateMap<UserRequest, UserCreate>();
    CreateMap<User, UserRequest>();
  }
}