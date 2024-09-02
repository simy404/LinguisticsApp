using LinguisticsAPI.Application.Repositories.News;
using LinguisticsAPI.Application.Repositories.NewsTranslation;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.NewsTranslation;

public class NewsTranslationReadRepository : ReadRepository<Domain.Entities.NewsTranslation> , INewsTranslationReadRepository
{
    public NewsTranslationReadRepository(LinguisticsAPIDbContext context) : base(context)
    {
    }
    
}