using LinguisticsAPI.Domain.Entities.Common;
using LinguisticsAPI.Domain.Entities.Identity;

namespace LinguisticsAPI.Domain.Entities;

public class News : BaseEntity
{
    public string ImagePath { get; set; }
    public DateTime PublicationDate { get; set; } 
    public string Author { get; set; }
    public string SourceLink { get; set; }
    
    public Guid SharedById { get; set; }
    public AppUser SharedBy { get; set; } 
    
    public ICollection<NewsTranslation> Translations { get; set; }
    public ICollection<Tag> Tags { get; set; }

}