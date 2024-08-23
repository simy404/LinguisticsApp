using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Domain.Entities.Common;
using LinguisticsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
	{
		private readonly LinguisticsAPIDbContext _context;
		public WriteRepository(LinguisticsAPIDbContext context)
		{
			_context = context;
		}

		public DbSet<T> Table => _context.Set<T>();

		public async Task<bool> AddAsync(T entity)
		{
			EntityEntry<T> entityEntry  = await Table.AddAsync(entity);
			
			return entityEntry.State == EntityState.Added;
		}

		public async Task<bool> AddRangeAsync(List<T> entity)
		{
			await Table.AddRangeAsync(entity);

			return true;
		}

		public bool Remove(T entity)
		{
			EntityEntry<T> entityEntry = Table.Remove(entity);

			return entityEntry.State == EntityState.Deleted;
		}

		public async Task<bool> Remove(Guid id)
		{
			var data = await Table.FirstOrDefaultAsync(Data => Data.Id.Equals(id));
			EntityEntry<T> entityEntry =  Table.Remove(data);

			return entityEntry.State == EntityState.Deleted;
		}

		public bool RemoveRange(List<T> entity)
		{
			Table.RemoveRange(entity);

			return true;
		}

		public bool Update(T entity)
		{
			EntityEntry entityEntry = Table.Update(entity);

			return entityEntry.State == EntityState.Modified;
		}

		public Task<int> SaveAsync() => _context.SaveChangesAsync();

	}
}
