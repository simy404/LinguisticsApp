using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinguisticsAPI.Application.Repositories.Link;
using LinguisticsAPI.Application.Repositories.LinkTopic;
using LinguisticsAPI.Application.ViewModel.LinkTopic;
using LinguisticsAPI.Domain.Entities;
using LinguisticsAPI.Infrastructure.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinguisticsAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LinkTopicController : ControllerBase
{
    private readonly  ILinkTopicWriteRepository _writeRepository;
    private readonly  ILinkTopicReadRepository _readRepository;
    private readonly ILinkReadRepository _linkReadRepository;
    private readonly ILinkWriteRepository _linkWriteRepository;
    private readonly IMapper _mapper;
    
    public LinkTopicController(ILinkTopicWriteRepository writeRepository, ILinkTopicReadRepository readRepository, ILinkReadRepository linkReadRepository, ILinkWriteRepository linkWriteRepository, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _linkReadRepository = linkReadRepository;
        _linkWriteRepository = linkWriteRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<LinkTopicVM>), StatusCodes.Status200OK)]
    public  async Task<ActionResult> GetAll() // ->  GET /linktopics
    {
        var linkQuery =  _readRepository.GetWhere(x => x.ParentId == null)
            .IncludeMultiple(
                x => x.SubTopics,
                x
                    => x.LinkList
            );
        
        var result = await linkQuery
            .ProjectTo<LinkTopicVM>(_mapper.ConfigurationProvider) 
            .ToListAsync();
        
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LinkTopicVM), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get(Guid id) // ->  GET /linktopics/{id}
    {
        var linkQuery = _readRepository.GetWhere(x => x.Id == id)
            .IncludeMultiple(x => x.SubTopics, x => x.LinkList);
           
        
        var result = await linkQuery
            .ProjectTo<LinkTopicVM>(_mapper.ConfigurationProvider) 
            .ToListAsync();
        
        if (result is null)
            return NotFound();

        return Ok(result);
    }
    
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Create([FromBody] LinkTopicCreateVM linkTopic) // ->  POST /linktopics
    {
        await _writeRepository.AddAsync(_mapper.Map<LinkTopic>(linkTopic));
        await _writeRepository.SaveAsync();
        return Ok(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Update(Guid id, [FromBody] LinkTopicCreateVM linkTopic) // ->  PUT /linktopics/{id}
    {
        var existingLinkTopic = await _readRepository.GetById(id, false);
        if (existingLinkTopic is null)
            return NotFound();
        
        var updatedLinkTopic = _mapper.Map<LinkTopic>(linkTopic);
        updatedLinkTopic.Id = id;

        _writeRepository.Update(updatedLinkTopic);
        await _writeRepository.SaveAsync();
        return Ok();
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Delete(Guid id) // ->  DELETE /linktopics/{id}
    {
        var existingLinkTopic =  await _readRepository.GetWhere(x => x.Id == id)
            .IncludeMultiple(
                x => x.SubTopics,
                x => x.LinkList
            ).FirstOrDefaultAsync();
        if (existingLinkTopic is null)
            return NotFound();
        else if (existingLinkTopic.SubTopics.Count > 0)
            return BadRequest("SubTopics exist");
        
        _writeRepository.Remove(existingLinkTopic);
        await _writeRepository.SaveAsync();
        return Ok();
    }
    
    [HttpGet("{id}/links")]
    public async Task<ActionResult> GetLinks(Guid id) // ->  GET /linktopics/{id}/links
    {
        // var linkTopic = await _readRepository.GetById(id, false);
        var linkTopic = _linkReadRepository.GetWhere(x => x.LinkTopicId == id);
        if (linkTopic is null)
            return NotFound();
        
        return Ok(_mapper.Map<IEnumerable<LinkVM>>(linkTopic));
    }
    
    [HttpPost("{id}/links")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateLink(Guid id, [FromBody] LinkCreateVM link) // ->  POST /linktopics/{id}/links
    {
        var linkTopic = await _readRepository.GetById(id);

        if (linkTopic is null)
            return NotFound();
        
        var newLink = _mapper.Map<Link>(link);
        newLink.LinkTopicId = id;
        
        await _linkWriteRepository.AddAsync(newLink);
        await _linkWriteRepository.SaveAsync();
        return Ok(StatusCodes.Status201Created);
    }
    
    [HttpPut("{id}/links/{linkId}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> UpdateLink(Guid id, Guid linkId, [FromBody] LinkCreateVM link) // ->  PUT /linktopics/{id}/links/{linkId}
    {
        var existingLink = await _linkReadRepository.GetById(linkId, false);
        if (existingLink is null)
            return NotFound();
        
        var newLink = _mapper.Map<Link>(link);
        newLink.LinkTopicId = id;
        newLink.Id = linkId;
        
        _linkWriteRepository.Update(newLink);
        await _linkWriteRepository.SaveAsync();
        return Ok(StatusCodes.Status200OK);
    }
    
    [HttpDelete("{id}/links/{linkId}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> DeleteLink(Guid id, Guid linkId) // ->  DELETE /linktopics/{id}/links/{linkId}
    {
        var existingLink = await _linkReadRepository.GetById(linkId);
        if (existingLink is null)
            return NotFound();
        
        _linkWriteRepository.Remove(existingLink);
        await _writeRepository.SaveAsync();
        return NoContent();
    }
    
}