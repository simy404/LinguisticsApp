using LinguisticsAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinguisticsAPI.Domain.Entities.Common;
using LinguisticsAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LinguisticsAPI.Persistence.Contexts
{
	public class LinguisticsAPIDbContext : IdentityDbContext<AppUser, AppRole, Guid>
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
			
			// LinkTopic -> SubTopics ilişkisi (Restict Delete) : Bir LinkTopic silinirken altındaki SubTopics silinmesin
			modelBuilder.Entity<LinkTopic>()
				.HasMany(lt => lt.SubTopics)
				.WithOne(lt => lt.Parent)
				.HasForeignKey(lt => lt.ParentId)
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Restrict);;
			
			// LinkTopic -> Link ilişkisi (Cascade Delete)
			modelBuilder.Entity<LinkTopic>()
				.HasMany(lt => lt.LinkList)
				.WithOne(l => l.LinkTopic)
				.HasForeignKey(l => l.LinkTopicId)
				.OnDelete(DeleteBehavior.Cascade);
			
			base.OnModelCreating(modelBuilder);
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
						{ State: EntityState.Modified } => entity.UpdatedAt = DateTime.Now,
						_ =>  null,
					};
				}
			});
			
			return base.SaveChangesAsync(cancellationToken);
		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Language> Languages { get; set; }
		public DbSet<ArticleTranslation> ArticleTranslation { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<News> News { get; set; }
		public DbSet<NewsTranslation> NewsTranslations { get; set; }
		public DbSet<Link> Links { get; set; }
		public DbSet<LinkTopic> LinkTopics { get; set; }
		
	}
}
