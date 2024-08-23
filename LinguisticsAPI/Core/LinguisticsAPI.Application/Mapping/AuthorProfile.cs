using AutoMapper;
using LinguisticsAPI.Application.ViewModel;
using LinguisticsAPI.Domain.Entities;

namespace LinguisticsAPI.Application.Mapping;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorVM>();
        CreateMap<AuthorVM, Author>();
        CreateMap<AuthorUpdateVM, Author>();
        CreateMap<AuthorCreateVM, Author>();
    }
}