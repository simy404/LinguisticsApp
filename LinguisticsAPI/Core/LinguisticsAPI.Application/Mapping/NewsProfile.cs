using AutoMapper;
using LinguisticsAPI.Application.DTOs;
using LinguisticsAPI.Domain.Entities;

namespace LinguisticsAPI.Application.Mapping;

public class NewsProfile : Profile
{
    public NewsProfile()
    {
        CreateMap<News, NewsDto>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags.Select(tag => tag.Name)))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations))
            .ForMember(dest => dest.SharedBy, opt => opt.MapFrom(src =>  new SharedByDto
            {
                Id = src.SharedBy.Id,
                ProfilePicture = src.SharedBy.ProfilePicture,
                FullName = src.SharedBy.FullName,
                Email = src.SharedBy.Email
            }));
        CreateMap<NewsTranslation, TranslationDto>();
    }

}