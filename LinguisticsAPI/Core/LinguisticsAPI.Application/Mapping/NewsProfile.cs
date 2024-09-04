using AutoMapper;
using LinguisticsAPI.Application.DTOs;
using LinguisticsAPI.Application.ViewModel.News;
using LinguisticsAPI.Application.ViewModel.NewsTranslation;
using LinguisticsAPI.Application.ViewModel.Tag;
using LinguisticsAPI.Domain.Entities;

namespace LinguisticsAPI.Application.Mapping;

public class NewsProfile : Profile
{
    public NewsProfile()
    {
        CreateMap<News, NewsVM>()
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
        
        CreateMap<NewsCreateVM, News>()
            .ForMember(dest => dest.SharedById, opt => opt.Ignore())  // userId'yi manuel olarak setleyeceğiz
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

        CreateMap<NewsTag, Tag>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => (DateTime?)null))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));

        CreateMap<NewsTranslationCreateVM, NewsTranslation>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => (DateTime?)null))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => false));
    }

}