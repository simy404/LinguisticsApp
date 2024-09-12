using LinguisticsAPI.Application.Repositories.Link;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.Link
{
	public class LinkWriteRepository : WriteRepository<Domain.Entities.Link>, ILinkWriteRepository
	{
		public LinkWriteRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
