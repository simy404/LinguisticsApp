using LinguisticsAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories
{
	public class AuthorWriteRepository : WriteRepository<Author>, IAuthorWriteRepository
	{
		public AuthorWriteRepository(LinguisticsAPIDbContext context) : base(context)
		{
		}
	}
}