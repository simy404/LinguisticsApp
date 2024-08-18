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
	internal class ArticleTranslationWriteRepository : WriteRepository<ArticleTranslation>, IArticleTranslationWriteRepository
	{
		public ArticleTranslationWriteRepository(LinguisticsAPIDbContext context) : base(context)
		{
		}
	}
}