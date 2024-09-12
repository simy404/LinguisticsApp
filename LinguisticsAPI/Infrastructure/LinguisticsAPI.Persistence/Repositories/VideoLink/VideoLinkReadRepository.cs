using LinguisticsAPI.Application.Repositories.VideoLink;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.VideoLink
{
	public class VideoLinkReadRepository : ReadRepository<Domain.Entities.VideoLink>, IVideoLinkReadRepository
	{
		public VideoLinkReadRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
