using LinguisticsAPI.Application.Repositories.News;
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
                Tags = n.Tags,
                Translations = n.Translations.Where(t => t.LanguageId == languageId).ToList()
            })
            .ToListAsync();
        
        var newsList2= await Table
            .Include(n => n.Translations)
            .ThenInclude(t => t.Language)
            .Where(n => n.Translations.Any(t => t.LanguageId == languageId))
            .ToListAsync();

        return newsList;
    }
}