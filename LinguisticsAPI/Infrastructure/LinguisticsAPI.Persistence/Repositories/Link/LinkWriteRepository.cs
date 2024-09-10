using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Application.Repositories.LinkTopic;
using LinguisticsAPI.Application.Repositories.News;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.LinkTopic
{
	public class LinkWriteRepository : WriteRepository<Domain.Entities.Link>, ILinkWriteRepository
	{
		public LinkWriteRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
