using AutoMapper;
using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Application.ViewModel.Language;
using LinguisticsAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers;

[Authorize()]
[Route("api/[controller]")]
[ApiController]
public class LanguageController : ControllerBase
{
    private readonly ILanguageReadRepository _readRepository;
    private readonly ILanguageWriteRepository _writeRepository;
    private readonly IMapper _mapper;
    
    public LanguageController(ILanguageReadRepository readRepository, ILanguageWriteRepository writeRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(LanguageVM), StatusCodes.Status200OK)]
    public  ActionResult GetAll()
    {
        var languages =  _readRepository.GetAll(false);
        return Ok(_mapper.Map<IEnumerable<LanguageVM>>(languages));
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(LanguageVM), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Get(Guid id)
    {
        var language = await _readRepository.GetById(id, false);
        if (language is null)
            return NotFound();

        return Ok(_mapper.Map<LanguageVM>(language));
    }
    
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult> Create([FromBody] LanguageCreateVM languageVM)
    {
        var language = _readRepository.GetWhere(l => languageVM.Code == l.Code);
        if (language.Any())
            return BadRequest("Language already exists");
        
        var newLanguage = _mapper.Map<Language>(languageVM);
        await _writeRepository.AddAsync(newLanguage);
        await _writeRepository.SaveAsync();
        return Ok(StatusCodes.Status201Created);
    }
    
    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> Update([FromBody] LanguageUpdateVM languageVM)
    {
        var language = await _readRepository.GetById(languageVM.Id, false);
        if (language is null)
            return NotFound("Language not found");
        
        _mapper.Map(languageVM, language);
         _writeRepository.Update(_mapper.Map<Language>(language));
        await _writeRepository.SaveAsync();
        return Ok("Language successfully updated");
    }
    
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var language = await _readRepository.GetById(id, false);
        if (language is null)
            return NotFound();

        await _writeRepository.Remove(id);
        await _writeRepository.SaveAsync();
        return NoContent();;
    }
    
    
}