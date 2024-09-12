using LinguisticsAPI.Application.Repositories.LinkTopic;
using LinguisticsAPI.Application.Repositories.VideoTopic;
using LinguisticsAPI.Persistence.Contexts;

namespace LinguisticsAPI.Persistence.Repositories.VideoTopic
{
	public class VideoTopicWriteRepository : WriteRepository<Domain.Entities.VideoTopic>, IVideoTopicWriteRepository
	{
		public VideoTopicWriteRepository(LinguisticsAPIDbContext dbContext) : base(dbContext)
		{
		}
	}
}
