using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinguisticsAPI.Domain.Entities;

namespace LinguisticsAPI.Persistence.Repositories
{
	public class TagReadRepository : ReadRepository<Tag>, ITagReadRepository
	{
		public TagReadRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
