using LinguisticsAPI.Application.Repositories.News;
using LinguisticsAPI.Domain.Entities;
using LinguisticsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LinguisticsAPI.Persistence.Repositories.News;

public class NewsReadRepository : ReadRepository<Domain.Entities.News>, INewsReadRepository
{   
    public NewsReadRepository(LinguisticsAPIDbContext context) : base(context)
    {
    }
    
    public async Task<List<Domain.Entities.News>?> GetNewsByLanguageIdAsync(Guid languageId)
    {
        
        var newsList = await _context.News
            .Where(n => n.Translations.Any(t => t.LanguageId == languageId))
            .Select(n => new Domain.Entities.News
            {
                Id = n.Id,
                Author = n.Author,
                ImagePath = n.ImagePath,
                SourceLink = n.SourceLink,
                SharedById = n.SharedById,
                Tags = n.Tags.Select(t => new Domain.Entities.Tag
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList(),
                Translations = n.Translations.Where(t => t.LanguageId == languageId)
                    .Select(t => new Domain.Entities.NewsTranslation
                    {
                        Id = t.Id,
                        LanguageId = t.LanguageId,
                        Title = t.Title,
                        Content = t.Content
                    }).ToList()
            })
            .ToListAsync();
        
        // var newsList2= await Table
        //     .Include(n => n.Translations)
        //     .ThenInclude(t => t.Language)
        //     .Where(n => n.Translations.Any(t => t.LanguageId == languageId))
        //     .ToListAsync();

        return newsList;
    }
}