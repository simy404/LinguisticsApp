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
		public string Title { get; set; }
		public string Content { get; set; }

		public int AuthorId { get; set; }

		public Author Author { get; set; }
		public ICollection<Tag> Tags { get; set; }

	}
}
