using LinguisticsAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Domain.Entities
{
	public class Tag : BaseEntity
	{
		public string Name { get; set; }

		public ICollection<Article> Articles { get; set; }
		public ICollection<News> NewsTags { get; set; }

	}
}
