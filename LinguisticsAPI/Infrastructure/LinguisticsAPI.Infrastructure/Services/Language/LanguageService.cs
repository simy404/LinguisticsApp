using LinguisticsAPI.Application.Abstraction.Language;
using LinguisticsAPI.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LinguisticsAPI.Infrastructure.Services.Language;

public class LanguageService : ILanguageService
{
    private readonly ILanguageReadRepository _languageReadRepository;
    
    public LanguageService(ILanguageReadRepository languageReadRepository)
    {
        _languageReadRepository = languageReadRepository;
    }
    
    public async Task<Guid> GetLanguageByCode(string languageCode)
    {
        var languageId = await _languageReadRepository.GetWhere(x => x.Code == languageCode)
            .Select(n => n.Id)
            .FirstOrDefaultAsync();

        if (languageId == Guid.Empty)
        {
            throw new Exception("Language not found");
        }

        return languageId;
    }
}