namespace LinguisticsAPI.Application.ViewModel.FieldTranslation;

public class FieldTranslationVM
{
    public Guid Id { get; set; }
    public string Title { get; set; } 
    public string Content { get; set; } 
    public string? Description { get; set; }
    public string LanguageCode { get; set; }
}