using AutoMapper;
using LinguisticsAPI.Application.Abstraction.News;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly INewsService _newsService;
    
    public NewsController(IMapper mapper, IConfiguration configuration, INewsService newsService)
    {
        _mapper = mapper;
        _configuration = configuration;
        _newsService = newsService;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll(string? languageCode)
    {
        return Ok(_newsService.GetAllNews(languageCode ?? _configuration["DefaultLanguage"]));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id, string? languageCode)
    {
        return Ok(_newsService.GetNewsById(id, languageCode ?? _configuration["DefaultLanguage"]));
    }
}