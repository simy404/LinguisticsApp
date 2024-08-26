using AutoMapper;
using LinguisticsAPI.Application.ViewModel.User;
using LinguisticsAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace LinguisticsAPI.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserCreateVM, AppUser>();
    }
}