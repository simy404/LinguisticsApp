using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace LinguisticsAPI.Infrastructure.Extension;



public static class QueryableExtensions
{
    public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        where T : class
    {
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        return query;
    }
}

