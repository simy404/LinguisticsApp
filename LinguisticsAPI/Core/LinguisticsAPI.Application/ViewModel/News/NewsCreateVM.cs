using LinguisticsAPI.Application.ViewModel.NewsTranslation;
using LinguisticsAPI.Application.ViewModel.Tag;
using LinguisticsAPI.Domain.Entities;

namespace LinguisticsAPI.Application.ViewModel.News;

public class NewsCreateVM
{
    public string Author { get; set; }
    public string ImagePath { get; set; }
    public string SourceLink { get; set; }
    public ICollection<NewsTag> Tags { get; set; }
    public ICollection<NewsTranslationCreateVM> Translations { get; set; }
}