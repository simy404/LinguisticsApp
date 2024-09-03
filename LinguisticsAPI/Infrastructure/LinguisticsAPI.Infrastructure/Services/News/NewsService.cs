using LinguisticsAPI.Application.Abstraction.News;
using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Application.Repositories.News;
using LinguisticsAPI.Application.Repositories.NewsTranslation;
using LinguisticsAPI.Application.ViewModel.News;
using LinguisticsAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LinguisticsAPI.Infrastructure.Services.News;

public class NewsService : INewsService
{
    private readonly INewsWriteRepository _newsWriteRepository;
    private readonly INewsReadRepository _newsReadRepository;
    private readonly INewsTranslationReadRepository _newsTranslationReadRepository;
    private readonly INewsTranslationWriteRepository _newsTranslationWriteRepository;
    private readonly ILanguageReadRepository _languageReadRepository;
    
    public NewsService(INewsWriteRepository newsWriteRepository, INewsReadRepository newsReadRepository, INewsTranslationReadRepository newsTranslationReadRepository, INewsTranslationWriteRepository newsTranslationWriteRepository, ILanguageReadRepository languageReadRepository)
    {
        _newsWriteRepository = newsWriteRepository;
        _newsReadRepository = newsReadRepository;
        _newsTranslationReadRepository = newsTranslationReadRepository;
        _newsTranslationWriteRepository = newsTranslationWriteRepository;
        _languageReadRepository = languageReadRepository;
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

    public async Task CreateNews(NewsCreateVM newsVM, string userId)
    {
        // 1. News nesnesini oluştur
        var news = new Domain.Entities.News
        {
            Author = newsVM.Author,
            ImagePath = newsVM.ImagePath,
            SourceLink = newsVM.SourceLink,
            SharedById = Guid.Parse(userId),
            Tags = newsVM.Tags.Select(t => new Tag
            {
                Name = t.Name,
                UpdatedAt = null,
                CreatedAt = DateTime.Now,
                IsDeleted = false
            }).ToList(),
            Translations = newsVM.Translations.Select(t => new NewsTranslation
            {
                Title = t.Title,
                Content = t.Content,
                LanguageId =   getLanguageByCode(t.LanguageCode).Result,
                UpdatedAt = null,
                CreatedAt = DateTime.Now,
                IsDeleted = false
                
            }).ToList()
        };

        // 2. News nesnesini ekle, EF otomatik olarak Translations'ları da ekleyecek
        await _newsWriteRepository.AddAsync(news);
        await _newsWriteRepository.SaveAsync();
    }

    private async Task<Guid> getLanguageByCode(string languageCode)
    {
        var language = await _languageReadRepository.GetWhere(x => x.Code == languageCode).FirstOrDefaultAsync();
       
        return language?.Id  ?? throw new Exception("Language not found");
    }
}