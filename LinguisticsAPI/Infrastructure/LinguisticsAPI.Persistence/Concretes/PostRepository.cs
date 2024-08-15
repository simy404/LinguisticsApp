using LinguisticsAPI.Application.Abstraction;
using LinguisticsAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Persistence.Concretes
{
	public class PostRepository : IPostRepository
	{
		public IQueryable<Post> GetPosts()
		{
			return new List<Post>()
			{ 
				new Post() { Id = Guid.NewGuid(), AuthorId = 1 ,Title = "Post 1", Content = "Content 1" },
				new Post() { Id = Guid.NewGuid(), Title = "Post 2", Content = "Content 2" },
				new Post() { Id = Guid.NewGuid(), Title = "Post 3", Content = "Content 3" }
			}.AsQueryable();
		}
	}
}
