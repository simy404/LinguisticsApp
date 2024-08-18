using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinguisticsAPI.Domain.Entities;
using LinguisticsAPI.Persistence.Contexts;
using LinguisticsAPI.Application.Repositories;

namespace LinguisticsAPI.Persistence.Repositories
{
	public class TagWriteRepository : WriteRepository<Tag>, ITagWriteRepository
	{
		public TagWriteRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
