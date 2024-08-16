using LinguisticsAPI.Persistence.Contexts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Persistence
{
	public static class Configuration
	{
		public static string GetConnectionString
		{
			get
			{
				ConfigurationManager configurationManager = new ConfigurationManager();
				configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/LinguisticsAPI.API"));
				configurationManager.AddJsonFile("appsettings.json");

				return configurationManager.GetConnectionString("MSSQL");
			}
		}
	}
}
