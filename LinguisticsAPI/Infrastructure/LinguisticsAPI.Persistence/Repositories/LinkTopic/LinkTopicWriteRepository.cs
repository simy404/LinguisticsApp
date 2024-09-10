using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Application.Repositories.LinkTopic;
using LinguisticsAPI.Application.Repositories.News;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.LinkTopic
{
	public class LinkTopicWriteRepository : WriteRepository<Domain.Entities.LinkTopic>, ILinkTopicWriteRepository
	{
		public LinkTopicWriteRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
