using LinguisticsAPI.Application.Abstraction;
using LinguisticsAPI.Persistence.Concretes;
using Microsoft.Extensions.DependencyInjection;
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
			services.AddSingleton<IPostRepository, PostRepository>();
		}
	}
}
