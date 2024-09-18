using LinguisticsAPI.Application.Repositories.FieldTranslation;
using LinguisticsAPI.Application.Repositories.LinguisticField;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.FieldTranslation;

public class FieldTranslationWriteRepository : WriteRepository<Domain.Entities.FieldTranslation>, IFieldTranslationWriteRepository
{
    public FieldTranslationWriteRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
    {
    }
}