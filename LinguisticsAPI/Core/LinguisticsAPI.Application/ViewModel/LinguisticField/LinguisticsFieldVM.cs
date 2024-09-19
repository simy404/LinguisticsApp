namespace LinguisticsAPI.Application.ViewModel.LinguisticField;

public class LinguisticsFieldVM
{
    public Guid Id { get; set; }
    public string Slug { get; set; }
    public List<Domain.Entities.FieldTranslation> Translations { get; set; }
}