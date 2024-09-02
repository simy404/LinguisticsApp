using LinguisticsAPI.Application.ViewModel.News;

namespace LinguisticsAPI.Application.Abstraction.News;

public interface INewsService
{
    Task<List<Domain.Entities.News>> GetAllNews(string? languageCode);
    Task<NewsVM> GetNewsById(Guid id, string? languageCode);
}