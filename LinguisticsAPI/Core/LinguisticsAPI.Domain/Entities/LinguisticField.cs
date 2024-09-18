using LinguisticsAPI.Domain.Entities.Common;

namespace LinguisticsAPI.Domain.Entities;

public class LinguisticField : BaseEntity
{
    public string Slug { get; set; }
    public ICollection<FieldTranslation> Translations { get; set; }
}