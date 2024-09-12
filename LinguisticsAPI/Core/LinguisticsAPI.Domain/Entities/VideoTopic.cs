using LinguisticsAPI.Domain.Entities.Common;

namespace LinguisticsAPI.Domain.Entities;

public class VideoTopic : BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public ICollection<VideoLink> VideoLinks { get; set; }
}