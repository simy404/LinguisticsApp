namespace LinguisticsAPI.Application.DTOs;

public class NewsDto
{
    public Guid Id { get; set; }
    public string Author { get; set; }
    public string ImagePath { get; set; }
    public string SourceLink { get; set; }
    
    public SharedByDto SharedBy { get; set; }
    public List<TranslationDto> Translations { get; set; }
    public List<string> Tags { get; set; }
}

public class TranslationDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string LanguageCode { get; set; }
}

public class TagDto
{
    public string Name { get; set; }
}

public class SharedByDto
{
    public Guid Id { get; set; }
    public string? ProfilePicture { get; set; }
    public string? FullName { get; set; }
    public string Email { get; set; }
}
    