namespace LinguisticsAPI.Application.RequestParameters.Common;

public class PagedResponse<T>
{
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public string? PreviousPageUrl { get; set; }
    public string? NextPageUrl { get; set; }
    public IEnumerable<T> Items { get; set; }
}