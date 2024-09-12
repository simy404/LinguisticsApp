using LinguisticsAPI.Application.Repositories.Link;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.Link
{
	public class LinkReadRepository : ReadRepository<Domain.Entities.Link>, ILinkReadRepository
	{
		public LinkReadRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
