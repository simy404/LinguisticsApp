using AutoMapper;
using LinguisticsAPI.Application.ViewModel.Language;
using LinguisticsAPI.Domain.Entities;

namespace LinguisticsAPI.Application.Mapping;

public class LanguageProfile : Profile
{
    public LanguageProfile()
    {
        CreateMap<Language, LanguageVM>();
        CreateMap<LanguageCreateVM, Language>();
        CreateMap<LanguageUpdateVM, Language>();
    }
}