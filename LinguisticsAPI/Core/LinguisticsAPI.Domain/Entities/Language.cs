using LinguisticsAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Domain.Entities
{
	public class Language : BaseEntity
	{
		public string Name { get; set; }
		public string Code { get; set; }

		public ICollection<ArticleTranslation> ArticleTranslations { get; set; }
	}
}
