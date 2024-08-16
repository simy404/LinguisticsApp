using LinguisticsAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Domain.Entities
{
	public class Author : BaseEntity
	{
		public string Name { get; set; }
		public string Bio { get; set; }
		public string Email { get; set; }

		public ICollection<Article> Articles { get; set; }

	}
}
