using LinguisticsAPI.Domain.Entities.Common;

namespace LinguisticsAPI.Domain.Entities;

public class FieldTranslation : BaseEntity
{
    public string Title { get; set; } 
    public string Content { get; set; } 
    public string? Description { get; set; }
    public LinguisticField LinguisticField { get; set; }
    public Guid LinguisticFieldId { get; set; }
    
    public Language Language { get; set; }
    public Guid LanguageId { get; set; }
}