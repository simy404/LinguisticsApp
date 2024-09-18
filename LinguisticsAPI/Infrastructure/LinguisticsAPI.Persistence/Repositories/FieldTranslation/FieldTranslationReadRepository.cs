using LinguisticsAPI.Application.Repositories.FieldTranslation;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.FieldTranslation;

public class FieldTranslationReadRepository : ReadRepository<Domain.Entities.FieldTranslation>, IFieldTranslationReadRepository
{
    public FieldTranslationReadRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
    {
    }
}