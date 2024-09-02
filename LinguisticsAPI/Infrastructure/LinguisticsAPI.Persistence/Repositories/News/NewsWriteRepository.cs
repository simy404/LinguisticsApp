using LinguisticsAPI.Application.Repositories.News;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.News;

public class NewsWriteRepository : WriteRepository<Domain.Entities.News>, INewsWriteRepository
{
    public NewsWriteRepository(LinguisticsAPIDbContext context) : base(context)
    {
    }
}