using AutoMapper;
using LinguisticsAPI.Application.ViewModel.VideoTopic;
using LinguisticsAPI.Domain.Entities;

namespace LinguisticsAPI.Application.Mapping;

public class VideoTopicProfile : Profile
{
    public VideoTopicProfile()
    {
        CreateMap<VideoTopicCreateVM, VideoTopic>();
        CreateMap<VideoLinkCreateVM, VideoLink>();
        CreateMap<VideoLink, VideoLinkVM>();
        CreateMap<VideoTopic, VideoTopicVM>();
    }
}