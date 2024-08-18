using LinguisticsAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Domain.Entities
{
	public class ArticleTranslation : BaseEntity
	{
		public Guid ArticleId { get; set; }
		public Article Article { get; set; }

		public Guid LanguageId { get; set; }
		public Language Language { get; set; }

		public string Title { get; set; }
		public string Content { get; set; }
	}

}
