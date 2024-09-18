using LinguisticsAPI.Application.Repositories.LinguisticField;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.LinguisticField;

public class LinguisticFieldReadRepository : ReadRepository<Domain.Entities.LinguisticField>, ILinguisticFieldReadRepository
{
    public LinguisticFieldReadRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
    {
    }
}