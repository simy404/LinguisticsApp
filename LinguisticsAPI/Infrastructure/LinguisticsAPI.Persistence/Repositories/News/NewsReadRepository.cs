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
    
   
}