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
using LinguisticsAPI.Application.Repositories.FieldTranslation;
using LinguisticsAPI.Application.Repositories.LinguisticField;
using LinguisticsAPI.Application.Repositories.Link;
using LinguisticsAPI.Application.Repositories.LinkTopic;
using LinguisticsAPI.Application.Repositories.News;
using LinguisticsAPI.Application.Repositories.NewsTranslation;
using LinguisticsAPI.Application.Repositories.VideoLink;
using LinguisticsAPI.Application.Repositories.VideoTopic;
using LinguisticsAPI.Domain.Entities.Identity;
using LinguisticsAPI.Persistence.Repositories.FieldTranslation;
using LinguisticsAPI.Persistence.Repositories.LinguisticField;
using LinguisticsAPI.Persistence.Repositories.Link;
using LinguisticsAPI.Persistence.Repositories.LinkTopic;
using LinguisticsAPI.Persistence.Repositories.News;
using LinguisticsAPI.Persistence.Repositories.NewsTranslation;
using LinguisticsAPI.Persistence.Repositories.VideoLink;
using LinguisticsAPI.Persistence.Repositories.VideoTopic;

namespace LinguisticsAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructure(this IServiceCollection services)
		{

			services.AddDbContext<LinguisticsAPIDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString));
			
			// Identity
			services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<LinguisticsAPIDbContext>();
			
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
			services.AddScoped<INewsReadRepository, NewsReadRepository>();
			services.AddScoped<INewsWriteRepository, NewsWriteRepository>();
			services.AddScoped<INewsTranslationWriteRepository, NewsTranslationWriteRepository>();
			services.AddScoped<INewsTranslationReadRepository, NewsTranslationReadRepository>();
			services.AddScoped<ILinkTopicReadRepository, LinkTopicReadRepository>();
			services.AddScoped<ILinkTopicWriteRepository, LinkTopicWriteRepository>();
			services.AddScoped<ILinkReadRepository, LinkReadRepository>();
			services.AddScoped<ILinkWriteRepository, LinkWriteRepository>();
			services.AddScoped<IVideoLinkReadRepository, VideoLinkReadRepository>();
			services.AddScoped<IVideoLinkWriteRepository, VideoLinkWriteRepository>();
			services.AddScoped<IVideoTopicReadRepository, VideoTopicReadRepository>();
			services.AddScoped<IVideoTopicWriteRepository, VideoTopicWriteRepository>();
			services.AddScoped<ILinguisticFieldReadRepository, LinguisticFieldReadRepository>();
			services.AddScoped<ILinguisticFieldWriteRepository, LinguisticFieldWriteRepository>();
			services.AddScoped<IFieldTranslationReadRepository, FieldTranslationReadRepository>();
			services.AddScoped<IFieldTranslationWriteRepository, FieldTranslationWriteRepository>();
		}
	}
}
