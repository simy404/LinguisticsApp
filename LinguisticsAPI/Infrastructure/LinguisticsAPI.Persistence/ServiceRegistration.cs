using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Domain.Entities;
using LinguisticsAPI.Persistence.Contexts;
using LinguisticsAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistence(this IServiceCollection services)
		{

			services.AddDbContext<LinguisticsAPIDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString));

			services.AddScoped<IArticleReadRepository, ArticleReadRepository>();
			services.AddScoped<IArticleWriteRepository, ArticleWriteRepository>();
			services.AddScoped<ILanguageReadRepository, LanguageReadRepository>();
			services.AddScoped<ILanguageWriteRepository, LanguageWriteRepository>();
			services.AddScoped<ITagReadRepository, TagReadRepository>();
			services.AddScoped<ITagWriteRepository, TagWriteRepository>();
			services.AddScoped<IArticleTranslationReadRepository, ArticleTranslationReadRepository>();
			services.AddScoped<IArticleTranslationWriteRepository, ArticleTranslationWriteRepository>();
			services.AddScoped<ITagReadRepository, TagReadRepository>();
			services.AddScoped<ITagWriteRepository, TagWriteRepository>();
			services.AddScoped<ILanguageReadRepository, LanguageReadRepository>();
			services.AddScoped<ILanguageWriteRepository, LanguageWriteRepository>();
			services.AddScoped<IAuthorReadRepository, AuthorReadRepository>();
			services.AddScoped<IAuthorWriteRepository, AuthorWriteRepository>();
		}
	}
}
