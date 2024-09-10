using AutoMapper;
using LinguisticsAPI.Application.ViewModel.LinkTopic;
using LinguisticsAPI.Domain.Entities;

namespace LinguisticsAPI.Application.Mapping;

public class LinkTopicProfile : Profile
{
    public LinkTopicProfile()
    {
        // ViewModel -> Entity
        CreateMap<LinkTopicCreateVM, LinkTopic>()
            .ForMember(dest => dest.LinkList, opt => opt.Ignore())
            .ForMember(dest => dest.SubTopics, opt => opt.Ignore());

        CreateMap<LinkCreateVM, Link>();

        CreateMap<LinkTopic, LinkTopicVM>()
            .ForMember(dest => dest.SubTopics, opt => opt.MapFrom(src => src.SubTopics))
            .ForMember(dest => dest.Links, opt => opt.MapFrom(src => src.LinkList));
        CreateMap<Link, LinkVM>();
    }
}