using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Domain.Entities;
using LinguisticsAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Persistence.Repositories
{
	public class ArticleWriteRepository : WriteRepository<Article>, IArticleWriteRepository
	{
		public ArticleWriteRepository(LinguisticsAPIDbContext context) : base(context)
		{
		}
	}
}
