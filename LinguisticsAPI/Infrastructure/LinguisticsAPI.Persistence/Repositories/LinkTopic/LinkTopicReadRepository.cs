using LinguisticsAPI.Application.Repositories.LinkTopic;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.LinkTopic
{
	public class LinkTopicReadRepository : ReadRepository<Domain.Entities.LinkTopic>, ILinkTopicReadRepository
	{
		public LinkTopicReadRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
