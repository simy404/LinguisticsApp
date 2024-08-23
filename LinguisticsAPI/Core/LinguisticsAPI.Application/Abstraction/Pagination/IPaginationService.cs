using LinguisticsAPI.Application.RequestParameters.Common;

namespace LinguisticsAPI.Application.Abstraction.Pagination;

public interface IPaginationService
{
    Task<PagedResponse<TDest>> GetPagedResponse<TDest, TSource>(IQueryable<TSource> query, string action, RequestParameters.Pagination p);
}

