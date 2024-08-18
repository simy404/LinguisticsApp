using LinguisticsAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinguisticsAPI.Domain.Entities.Common;

namespace LinguisticsAPI.Persistence.Contexts
{
	public class LinguisticsAPIDbContext : DbContext
	{
		public LinguisticsAPIDbContext(DbContextOptions options) : base(options)
		{

		}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Author -> Article ilişkisini optional yapıyoruz
			modelBuilder.Entity<Author>()
				.HasMany(a => a.Articles)
				.WithOne(b => b.Author)
				.IsRequired(false); // Author oluşturulurken Article zorunlu değil
		}
		
		//Intercepter
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var data = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted);
			
			data.ToList().ForEach(e =>
			{
				if (e.Entity is BaseEntity entity)
				{
					_ = e switch {
						{ State: EntityState.Added } => entity.CreatedAt = DateTime.Now,
						{ State: EntityState.Modified } => entity.UpdatedAt = DateTime.Now,};
				}
			});
			
			return base.SaveChangesAsync(cancellationToken);
		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<ArticleTranslation> ArticleTranslations { get; set; }
		public DbSet<Tag> Tags { get; set; }
	}
}
