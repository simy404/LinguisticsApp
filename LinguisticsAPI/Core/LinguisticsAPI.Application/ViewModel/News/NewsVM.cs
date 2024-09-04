using LinguisticsAPI.Application.DTOs;

namespace LinguisticsAPI.Application.ViewModel.News;

public class NewsVM
{
    public Guid Id { get; set; }
    public string Author { get; set; }
    public string ImagePath { get; set; }
    public string SourceLink { get; set; }
    
    public SharedByDto SharedBy { get; set; }
    public List<TranslationDto> Translations { get; set; }
    public List<string> Tags { get; set; }
}