using LinguisticsAPI.Application.Repositories.LinguisticField;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.LinguisticField;

public class LinguisticFieldWriteRepository : WriteRepository<Domain.Entities.LinguisticField>,ILinguisticFieldWriteRepository
{
    public LinguisticFieldWriteRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
    {
    }
}