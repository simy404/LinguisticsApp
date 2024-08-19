namespace LinguisticsAPI.Application.RequestParameters;

public record Pagination
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}