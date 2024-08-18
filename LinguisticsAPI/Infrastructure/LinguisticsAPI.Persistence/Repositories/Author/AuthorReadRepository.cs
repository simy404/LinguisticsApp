using LinguisticsAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Domain.Entities;

namespace LinguisticsAPI.Persistence.Repositories
{
	public class AuthorReadRepository : ReadRepository<Author>, IAuthorReadRepository
	{
		public AuthorReadRepository(LinguisticsAPIDbContext context) : base(context)
		{
		}
	}
}
