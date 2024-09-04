using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinguisticsAPI.Application.Abstraction.Language;
using LinguisticsAPI.Application.Abstraction.News;
using LinguisticsAPI.Application.DTOs;
using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Application.Repositories.News;
using LinguisticsAPI.Application.Repositories.NewsTranslation;
using LinguisticsAPI.Application.RequestParameters.Common;
using LinguisticsAPI.Application.ViewModel.News;
using LinguisticsAPI.Domain.Entities;
using LinguisticsAPI.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;

namespace LinguisticsAPI.Infrastructure.Services.News;

public class NewsService : INewsService
{
    private readonly INewsWriteRepository _newsWriteRepository;
    private readonly INewsReadRepository _newsReadRepository;
    private readonly INewsTranslationReadRepository _newsTranslationReadRepository;
    private readonly INewsTranslationWriteRepository _newsTranslationWriteRepository;
    private readonly ILanguageService _languageService;
    private readonly IMapper _mapper;
    
    public NewsService(INewsWriteRepository newsWriteRepository, INewsReadRepository newsReadRepository, INewsTranslationReadRepository newsTranslationReadRepository, INewsTranslationWriteRepository newsTranslationWriteRepository, ILanguageService languageService, IMapper mapper)
    {
        _newsWriteRepository = newsWriteRepository;
        _newsReadRepository = newsReadRepository;
        _newsTranslationReadRepository = newsTranslationReadRepository;
        _newsTranslationWriteRepository = newsTranslationWriteRepository;
        _languageService = languageService;
        _mapper = mapper;
    }
    
    public async Task<List<NewsDto>> GetAllNews(string? languageCode)
    {
        if (string.IsNullOrEmpty(languageCode))
            throw new ArgumentNullException(nameof(languageCode));

        var languageId = await _languageService.GetLanguageByCode(languageCode);
        
        var newsQuery = _newsReadRepository.GetAll()
            .IncludeMultiple(
                n => n.Translations,
                n => n.Tags
            ).Where(n => n.Translations.Any(t => t.LanguageId == languageId));
        
        var result = await newsQuery
            .ProjectTo<NewsDto>(_mapper.ConfigurationProvider) 
            .ToListAsync();
        
        return result;
    }

    public async Task<NewsDto> GetNewsById(Guid id, string? languageCode)
    {
        if (string.IsNullOrEmpty(languageCode))
            throw new ArgumentNullException(nameof(languageCode));

        var languageId = await _languageService.GetLanguageByCode(languageCode);
        
        var newsQuery = _newsReadRepository.GetWhere(n => n.Id == id)
            .IncludeMultiple(
                n => n.Translations,
                n => n.Tags
            ).Where(n => n.Translations.Any(t => t.LanguageId == languageId));

        var result = await newsQuery
            .ProjectTo<NewsDto>(_mapper.ConfigurationProvider) 
            .FirstOrDefaultAsync();
        
        return result;
    }

    public async Task CreateNews(NewsCreateVM newsVM, string userId)
    {
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
                LanguageId = _languageService.GetLanguageByCode(t.LanguageCode).Result,
                UpdatedAt = null,
                CreatedAt = DateTime.Now,
                IsDeleted = false
                
            }).ToList()
        };
        
        await _newsWriteRepository.AddAsync(news);
        await _newsWriteRepository.SaveAsync();
    }
    
}