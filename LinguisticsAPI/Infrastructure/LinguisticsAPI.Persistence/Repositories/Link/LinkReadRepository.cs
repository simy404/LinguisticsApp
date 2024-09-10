using LinguisticsAPI.Application.Repositories.LinkTopic;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.LinkTopic
{
	public class LinkReadRepository : ReadRepository<Domain.Entities.Link>, ILinkReadRepository
	{
		public LinkReadRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
