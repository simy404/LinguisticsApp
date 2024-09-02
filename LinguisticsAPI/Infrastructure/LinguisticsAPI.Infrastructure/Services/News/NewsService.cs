using LinguisticsAPI.Application.Abstraction.News;
using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Application.Repositories.News;
using LinguisticsAPI.Application.Repositories.NewsTranslation;
using LinguisticsAPI.Application.ViewModel.News;
using Microsoft.EntityFrameworkCore;

namespace LinguisticsAPI.Infrastructure.Services.News;

public class NewsService : INewsService
{
    private readonly INewsWriteRepository _newsWriteRepository;
    private readonly INewsReadRepository _newsReadRepository;
    private readonly INewsTranslationReadRepository _newsTranslationReadRepository;
    private readonly INewsTranslationWriteRepository _newsTranslationWriteRepository;
    private readonly ILanguageReadRepository _languageReadRepository;
    
    public NewsService(INewsWriteRepository newsWriteRepository, INewsReadRepository newsReadRepository)
    {
        _newsWriteRepository = newsWriteRepository;
        _newsReadRepository = newsReadRepository;
    }
    
    public async Task<List<Domain.Entities.News>> GetAllNews(string? languageCode)
    {
        if (string.IsNullOrEmpty(languageCode))
            throw new ArgumentNullException(nameof(languageCode));
        
        var languageId = await getLanguageByCode(languageCode);
        var news = await _newsReadRepository.GetNewsByLanguageIdAsync(languageId);

        return news;
    }

    public Task<NewsVM> GetNewsById(Guid id, string? languageCode)
    {
        throw new NotImplementedException();
    }
    
    private async Task<Guid> getLanguageByCode(string languageCode)
    {
        var language = await _languageReadRepository.GetWhere(x => x.Code == languageCode).FirstOrDefaultAsync();
        
        return language.Id;
    }
}