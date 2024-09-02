namespace LinguisticsAPI.Application.Repositories.News;

public interface INewsReadRepository : IReadRepository<Domain.Entities.News>
{
    Task<List<Domain.Entities.News>?> GetNewsByLanguageIdAsync(Guid languageId);
}