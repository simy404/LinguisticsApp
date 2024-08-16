using LinguisticsAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Domain.Entities
{
	public class Article : BaseEntity
	{
		public int AuthorId { get; set; }

		public Author Author { get; set; }
		public ICollection<ArticleTranslation> Translations { get; set; }

		public ICollection<Tag> Tags { get; set; }

	}
}
