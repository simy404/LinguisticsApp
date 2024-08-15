using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Domain.Entities.Common
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime? CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public DateTime? PublishedAt { get; set; }
		public bool IsPublished { get; set; }
		public bool IsDeleted { get; set; }
		public int CreatedBy { get; set; }
		public int UpdatedBy { get; set; }
		public int DeletedBy { get; set; }
	}
}
