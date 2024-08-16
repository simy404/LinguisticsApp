using LinguisticsAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Persistence.Contexts
{
	public class LinguisticsAPIDbContext : DbContext
	{
		public LinguisticsAPIDbContext(DbContextOptions options) : base(options)
		{

		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<ArticleTranslation> ArticleTranslations { get; set; }
		public DbSet<Tag> Tags { get; set; }
	}
}
