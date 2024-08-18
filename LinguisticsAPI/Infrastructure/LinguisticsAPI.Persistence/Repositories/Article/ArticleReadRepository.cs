using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Domain.Entities;
using LinguisticsAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Persistence.Repositories
{
	public class ArticleReadRepository : ReadRepository<Article> , IArticleReadRepository
	{
		public ArticleReadRepository(LinguisticsAPIDbContext context) : base(context)
		{
		}
	}
}
