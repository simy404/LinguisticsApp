namespace LinguisticsAPI.Application.Abstraction.Language;

public interface ILanguageService
{
    Task<Guid> GetLanguageByCode(string languageCode);
}