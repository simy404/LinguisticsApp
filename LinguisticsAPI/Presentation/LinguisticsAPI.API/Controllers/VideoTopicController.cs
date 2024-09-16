using LinguisticsAPI.Application.Repositories.VideoTopic;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoController
{
        private readonly IVideoTopicWriteRepository _writeRepository;
        private readonly IVideoTopicReadRepository _readRepository;
        
        public VideoController(IVideoTopicWriteRepository writeRepository, IVideoTopicReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }
        
        [HttpGet]
        public ActionResult Get()
        {
            var videoTopics = _readRepository.GetAll();
            return Ok(videoTopics);
        }
}