using AutoMapper;
using LinguisticsAPI.Application.Abstraction.Pagination;
using LinguisticsAPI.Application.RequestParameters.Common;
using Microsoft.EntityFrameworkCore;
using rp = LinguisticsAPI.Application.RequestParameters;
namespace LinguisticsAPI.Infrastructure.Services.Pagination;

public class PaginationService : IPaginationService
{   
    private readonly IMapper _mapper;

    public PaginationService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<PagedResponse<TDest>> GetPagedResponse<TDest,TSource>(IQueryable<TSource> query, string? action,
        rp.Pagination p)
    {
        var pagedNumarable = await query.Skip((p.PageNumber - 1) * p.PageSize)
            .Take(p.PageSize).Select(x => _mapper.Map<TDest>(x)).ToListAsync();
        
        
        var totalCount = query.Count();
        var totalPages = (int)Math.Ceiling(totalCount / (double)p.PageSize);
        return new PagedResponse<TDest>
        {
            TotalCount = totalCount,
            PageNumber = p.PageNumber,
            PageSize = p.PageSize,
            Items = pagedNumarable,
            PreviousPageUrl = PreviousPageUrl(p.PageNumber, p.PageSize, action),
            NextPageUrl = NextPageUrl(p.PageNumber, p.PageSize, totalPages, action)
        };
    }
    
    private string? PreviousPageUrl(int pageNumber, int pageSize, string action)
        => pageNumber > 1 ? 
            $"{action!}?{nameof(rp.Pagination.PageNumber)}={pageNumber - 1}&{nameof(rp.Pagination.PageSize)}={pageSize}" 
            : null;
    
    private string? NextPageUrl(int pageNumber, int pageSize, int totalPages, string action)
        =>  pageNumber < totalPages ? 
            $"{action!}?{nameof(rp.Pagination.PageNumber)}={pageNumber + 1}&{nameof(rp.Pagination.PageSize)}={pageSize}"
            : null;
}