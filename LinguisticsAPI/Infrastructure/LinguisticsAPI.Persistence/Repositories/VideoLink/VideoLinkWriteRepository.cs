using LinguisticsAPI.Application.Repositories.VideoLink;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.VideoLink
{
	public class VideoLinkWriteRepository : WriteRepository<Domain.Entities.VideoLink>, IVideoLinkWriteRepository
	{
		public VideoLinkWriteRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
