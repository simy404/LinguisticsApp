using LinguisticsAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Application.Abstraction
{
	public interface IPostRepository
	{
		IQueryable<Post> GetPosts();
	}
}
