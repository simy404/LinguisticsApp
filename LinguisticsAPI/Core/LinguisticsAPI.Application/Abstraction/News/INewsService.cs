using LinguisticsAPI.Application.DTOs;
using LinguisticsAPI.Application.RequestParameters.Common;
using LinguisticsAPI.Application.ViewModel.News;

namespace LinguisticsAPI.Application.Abstraction.News;

public interface INewsService
{
    Task<List<NewsDto>> GetAllNews(string? languageCode);
    Task<NewsDto> GetNewsById(Guid id, string? languageCode);
    
    Task CreateNews(NewsCreateVM newsVM, string userId);
}