using System.Text.Json.Serialization;
using LinguisticsAPI.Domain.Entities.Common;

namespace LinguisticsAPI.Domain.Entities;

public class LinkTopic : BaseEntity
{
    public string Title { get; set; }
   
    public Guid? ParentId { get; set; }
    
    [JsonIgnore]
    public virtual LinkTopic Parent { get; set; } 
    public virtual ICollection<LinkTopic> SubTopics { get; set; } 
    public ICollection<Link> LinkList { get; set; } 
}