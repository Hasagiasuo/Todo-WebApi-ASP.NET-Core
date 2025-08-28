using AutoMapper;
using Todo.Application.DTO;
using Todo.Domain.Models;

namespace Todo.Application.Mapping.Profiles;

public class ItemProfile : Profile
{
  public ItemProfile()
  {
    CreateMap<ItemCreate, Item>()
      .ForMember(dest => dest.User, opt => opt.Ignore()); 
    CreateMap<ItemResponce, Item>(); 
    CreateMap<ItemUpdate, Item>(); 
  } 
}