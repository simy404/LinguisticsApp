using LinguisticsAPI.Application.Repositories.NewsTranslation;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.NewsTranslation;

public class NewsTranslationWriteRepository : WriteRepository<Domain.Entities.NewsTranslation> , INewsTranslationWriteRepository
{
    public NewsTranslationWriteRepository(LinguisticsAPIDbContext context) : base(context)
    {
    }
}