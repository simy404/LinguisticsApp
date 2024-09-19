using AutoMapper;
using LinguisticsAPI.Application.ViewModel.FieldTranslation;
using LinguisticsAPI.Application.ViewModel.LinguisticField;
using LinguisticsAPI.Domain.Entities;

namespace LinguisticsAPI.Application.Mapping;

public class LinguisticsFieldProfile : Profile
{
    public LinguisticsFieldProfile()
    {
         CreateMap<LinguisticField, LinguisticsFieldVM>()
            .ForMember(dest => dest.Translations, opt => opt.MapFrom(src => src.Translations));

         CreateMap<FieldTranslation, FieldTranslationVM>();
    }
}