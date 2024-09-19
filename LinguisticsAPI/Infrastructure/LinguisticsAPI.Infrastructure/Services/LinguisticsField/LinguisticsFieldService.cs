using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinguisticsAPI.Application.Abstraction.Language;
using LinguisticsAPI.Application.Abstraction.LinguisticsField;
using LinguisticsAPI.Application.Repositories.LinguisticField;
using LinguisticsAPI.Application.ViewModel.LinguisticField;
using LinguisticsAPI.Application.ViewModel.News;
using LinguisticsAPI.Infrastructure.Extension;
using Microsoft.EntityFrameworkCore;

namespace LinguisticsAPI.Infrastructure.Services.LinguisticsField;

public class LinguisticsFieldService : ILanguisticsFieldService
{
    private readonly ILinguisticFieldWriteRepository _linguisticsFieldWriteRepository;
    private readonly ILinguisticFieldReadRepository _linguisticsFieldReadRepository;
    private readonly IMapper _mapper;
    private readonly ILanguageService _languageService;
    
    public LinguisticsFieldService(ILinguisticFieldWriteRepository linguisticsFieldWriteRepository, ILinguisticFieldReadRepository linguisticsFieldReadRepository, IMapper mapper, ILanguageService languageService)
    {
        _linguisticsFieldWriteRepository = linguisticsFieldWriteRepository;
        _linguisticsFieldReadRepository = linguisticsFieldReadRepository;
        _languageService = languageService;
        _mapper = mapper;
    }
    
    public async Task<List<LinguisticsFieldVM>> GetAllLinguisticsField(string? languageCode)
    {
        if (string.IsNullOrEmpty(languageCode))
            throw new ArgumentNullException(nameof(languageCode));

        var languageId = await _languageService.GetLanguageByCode(languageCode);
        
        var newsQuery = _linguisticsFieldReadRepository.GetAll() 
            .IncludeMultiple(
                n => n.Translations
                ).Where(n => n.Translations.Any(t => t.LanguageId == languageId));
        
        var result = await newsQuery
            .ProjectTo<LinguisticsFieldVM>(_mapper.ConfigurationProvider) 
            .ToListAsync();
        
        return result;
    }

    public async Task<LinguisticsFieldVM> GetLinguisticsFieldById(Guid id, string? languageCode)
    {
        if (string.IsNullOrEmpty(languageCode))
            throw new ArgumentNullException(nameof(languageCode));

        var languageId = await _languageService.GetLanguageByCode(languageCode);
        
        var newsQuery = _linguisticsFieldReadRepository.GetWhere(x => x.Id == id) 
            .IncludeMultiple(
                n => n.Translations
            ).Where(n => n.Translations.Any(t => t.LanguageId == languageId));
        
        var result = await newsQuery
            .ProjectTo<LinguisticsFieldVM>(_mapper.ConfigurationProvider) 
            .FirstOrDefaultAsync();
        
        return result;
    }

    public Task CreateLinguisticsField(LinguisticsFieldCreateVM linguisticsFieldVM, string userId)
    {
        throw new NotImplementedException();
    }
}