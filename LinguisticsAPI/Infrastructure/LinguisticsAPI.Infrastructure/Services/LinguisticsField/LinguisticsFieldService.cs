using AutoMapper;
using LinguisticsAPI.Application.Abstraction.LinguisticsField;
using LinguisticsAPI.Application.Repositories.LinguisticField;
using LinguisticsAPI.Application.ViewModel.LinguisticField;

namespace LinguisticsAPI.Infrastructure.Services.LinguisticsField;

public class LinguisticsFieldService : ILanguisticsFieldService
{
    private readonly ILinguisticFieldWriteRepository _linguisticsFieldWriteRepository;
    private readonly ILinguisticFieldReadRepository _linguisticsFieldReadRepository;
    private readonly IMapper _mapper;
    
    public LinguisticsFieldService(ILinguisticFieldWriteRepository linguisticsFieldWriteRepository, ILinguisticFieldReadRepository linguisticsFieldReadRepository, IMapper mapper)
    {
        _linguisticsFieldWriteRepository = linguisticsFieldWriteRepository;
        _linguisticsFieldReadRepository = linguisticsFieldReadRepository;
        _mapper = mapper;
    }
    
    public Task<List<LinguisticsFieldVM>> GetAllLinguisticsField(string? languageCode)
    {
        throw new NotImplementedException();
    }

    public Task<LinguisticsFieldVM> GetLinguisticsFieldById(Guid id, string? languageCode)
    {
        throw new NotImplementedException();
    }

    public Task CreateLinguisticsField(LinguisticsFieldCreateVM linguisticsFieldVM, string userId)
    {
        throw new NotImplementedException();
    }
}