using LinguisticsAPI.Domain.Entities.Common;
using System.Xml.Linq;

namespace LinguisticsAPI.Domain.Entities
{
	public class Post : BaseEntity
	{
		public string? Title { get; set; }
		public string? Content { get; set; }
		public int AuthorId { get; set; }
	}
}
