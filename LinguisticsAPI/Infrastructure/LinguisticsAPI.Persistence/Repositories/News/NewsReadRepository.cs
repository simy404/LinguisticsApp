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
        var newsList = await Table
            .Include(n => n.Translations)
            .Where(n => n.Translations.Any(t => t.LanguageId == languageId))
            .ToListAsync();

        return newsList;
    }
}