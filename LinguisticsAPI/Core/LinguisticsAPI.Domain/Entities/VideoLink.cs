using LinguisticsAPI.Domain.Entities.Common;

namespace LinguisticsAPI.Domain.Entities;

public class VideoLink : BaseEntity
{
    public string Url { get; set; }
    public string Description { get; set; }
    public string? Format { get; set; }
    public Guid VideoTopicId { get; set; }
    public VideoTopic VideoTopic { get; set; }
}