using LinguisticsAPI.Domain.Entities.Common;

namespace LinguisticsAPI.Domain.Entities;

public class Link : BaseEntity
{
    public string Url { get; set; }
    public string Description { get; set; }
    public Guid LinkTopicId { get; set; }
    public LinkTopic LinkTopic { get; set; }
}