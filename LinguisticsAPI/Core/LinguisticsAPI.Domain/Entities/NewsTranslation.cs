using LinguisticsAPI.Domain.Entities.Common;

namespace LinguisticsAPI.Domain.Entities;

public class NewsTranslation : BaseEntity
{
    public string Title { get; set; }
    public string Content { get; set; }
    
    public Guid NewsId { get; set; }
    public News News { get; set; }
    
    public Language Language { get; set; }
    public Guid LanguageId { get; set; }
}