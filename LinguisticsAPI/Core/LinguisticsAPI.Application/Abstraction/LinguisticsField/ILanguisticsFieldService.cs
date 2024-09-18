using LinguisticsAPI.Application.ViewModel.LinguisticField;

namespace LinguisticsAPI.Application.Abstraction.LinguisticsField;

public interface ILanguisticsFieldService
{
    Task<List<LinguisticsFieldVM>> GetAllLinguisticsField(string? languageCode);
    Task<LinguisticsFieldVM> GetLinguisticsFieldById(Guid id, string? languageCode);
    Task CreateLinguisticsField(LinguisticsFieldCreateVM linguisticsFieldVM, string userId);
}