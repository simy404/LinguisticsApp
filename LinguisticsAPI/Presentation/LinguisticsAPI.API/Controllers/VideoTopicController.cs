using AutoMapper;
using LinguisticsAPI.Application.Repositories.VideoLink;
using LinguisticsAPI.Application.Repositories.VideoTopic;
using LinguisticsAPI.Application.ViewModel.VideoTopic;
using LinguisticsAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideoTopicController : ControllerBase
{
        private readonly IVideoTopicWriteRepository _writeRepository;
        private readonly IVideoTopicReadRepository _readRepository;
        private readonly IVideoLinkReadRepository _videoLinkReadRepository;
        private readonly IVideoLinkWriteRepository _videoLinkWriteRepository;
        private readonly IMapper _mapper;
        
        
        public VideoTopicController(IVideoTopicWriteRepository writeRepository, IVideoTopicReadRepository readRepository, IMapper mapper, IVideoLinkReadRepository videoLinkReadRepository, IVideoLinkWriteRepository videoLinkWriteRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _mapper = mapper;
            _videoLinkReadRepository = videoLinkReadRepository;
            _videoLinkWriteRepository = videoLinkWriteRepository;
        }
        
        [HttpGet]
        public ActionResult Get() // ->  GET /videotopics
        {
            var videoTopics = _readRepository.GetAll(false);
            return Ok(_mapper.Map<IEnumerable<VideoTopicVM>>(videoTopics));
        }
        
        [HttpGet("{id}")]   
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(Guid id) // ->  GET /videotopics/{id}
        {
            var videoTopic =await  _readRepository.GetById(id, false);
            if (videoTopic is null)
                return NotFound();
            return Ok(_mapper.Map<VideoTopicVM>(videoTopic));
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult> Create([FromBody] VideoTopicCreateVM videoTopic) // ->  POST /videotopics
        {
            await _writeRepository.AddAsync(_mapper.Map<VideoTopic>(videoTopic));
            await _writeRepository.SaveAsync();
            return Ok();
        }
        
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update(Guid id, [FromBody] VideoTopicCreateVM videoTopic) // ->  PUT /videotopics/{id}
        {
            var existingVideoTopic = await _readRepository.GetById(id, false);
            if (existingVideoTopic is null)
                return NotFound();
            
            var updatedVideoTopic = _mapper.Map<VideoTopic>(videoTopic);
            updatedVideoTopic.Id = id;
            
            _writeRepository.Update(updatedVideoTopic);
            await _writeRepository.SaveAsync();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Delete(Guid id) // ->  DELETE /videotopics/{id}
        {
            var existingVideoTopic = await  _readRepository.GetById(id, false);
            if (existingVideoTopic is null)
                return NotFound();
            
            _writeRepository.Remove(existingVideoTopic);
            await _writeRepository.SaveAsync();
            return Ok();
        }
        
        [HttpGet("{id}/links")]
        public async Task<ActionResult> GetVideoLinks(Guid id) // ->  GET /videotopics/{id}/links
        {
            var videoLinks = _videoLinkReadRepository.GetWhere(x => x.VideoTopicId == id);
            return Ok(_mapper.Map<IEnumerable<VideoLinkVM>>(videoLinks));
        }
        
        
        [HttpPost("{id}/links")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateVideoLink(Guid id, [FromBody] VideoLinkCreateVM videoLink) // ->  POST /videotopics/{id}/links
        {
            var videoTopic = await _readRepository.GetById(id, false);
            if (videoTopic is null)
                return NotFound();
            
            var newVideoLink = _mapper.Map<VideoLink>(videoLink);
            newVideoLink.VideoTopicId = id;
            
            await _videoLinkWriteRepository.AddAsync(newVideoLink);
            await _videoLinkWriteRepository.SaveAsync();
            return Ok();
        }
        
        [HttpPut("{id}/links/{linkId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> UpdateVideoLink(Guid id, Guid linkId, [FromBody] VideoLinkCreateVM videoLink) // ->  PUT /videotopics/{id}/links/{linkId}
        {
            var existingVideoLink = await _videoLinkReadRepository.GetById(linkId, false);
            if (existingVideoLink is null)
                return NotFound();
            
            var updatedVideoLink = _mapper.Map<VideoLink>(videoLink);
            updatedVideoLink.Id = linkId;
            updatedVideoLink.VideoTopicId = id;
            
            _videoLinkWriteRepository.Update(updatedVideoLink);
            await _videoLinkWriteRepository.SaveAsync();
            return Ok();
        }
        
        [HttpDelete("{id}/links/{linkId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteVideoLink(Guid id, Guid linkId) // ->  DELETE /videotopics/{id}/links/{linkId}
        {
            var existingVideoLink = await _videoLinkReadRepository.GetById(linkId);
            if (existingVideoLink is null)
                return NotFound();
            
            _videoLinkWriteRepository.Remove(existingVideoLink);
            await _videoLinkWriteRepository.SaveAsync();
            return NoContent();
        }
}