using LinguisticsAPI.Application.Repositories.LinkTopic;
using LinguisticsAPI.Application.Repositories.VideoTopic;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.VideoTopic
{
	public class VideoTopicReadRepository : ReadRepository<Domain.Entities.VideoTopic>, IVideoTopicReadRepository
	{
		public VideoTopicReadRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
