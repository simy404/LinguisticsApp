using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Domain.Entities.Common;
using LinguisticsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace LinguisticsAPI.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
	{
		private readonly LinguisticsAPIDbContext _context;
		public ReadRepository(LinguisticsAPIDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public IQueryable<T> GetAll(bool tracking = true)
		{
			var query = Table.AsQueryable();

			if (!tracking)
			{
				query = query.AsNoTracking();
			} 
			return query;
		}

		public async Task<T> GetById(Guid id, bool tracking = true) 
		{
			var query = Table.AsQueryable();

			if (!tracking)
			{
				query = query.AsNoTracking();
			}
			return await query.FirstOrDefaultAsync(entity => entity.Id.Equals(id));
		}

		public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
		{
			var query = Table.AsQueryable();

			if (!tracking)
			{
				query = query.AsNoTracking();
			}

			return await query.SingleOrDefaultAsync(method);
		}

		public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true) 
		{
			var query = Table.Where(method);

			if (!tracking)
			{
				query = query.AsNoTracking();
			}
			return query;
		}
	}
}
