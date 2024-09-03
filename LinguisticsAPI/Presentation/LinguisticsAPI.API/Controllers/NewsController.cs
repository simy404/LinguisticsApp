using System.Security.Claims;
using AutoMapper;
using LinguisticsAPI.Application.Abstraction.News;
using LinguisticsAPI.Application.ViewModel.News;
using Microsoft.AspNetCore.Authorization;
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
        return Ok(await _newsService.GetAllNews(languageCode ?? _configuration["DefaultLanguage"]));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(Guid id, string? languageCode)
    {
        return Ok(_newsService.GetNewsById(id, languageCode ?? _configuration["DefaultLanguage"]));
    }
    
    [HttpPost]
    [Authorize]
    public async Task<ActionResult> Create([FromBody] NewsCreateVM newsVM)
    {
        var userId =  User.FindFirst("id")?.Value;
        await _newsService.CreateNews(newsVM, userId);
        return Ok(StatusCodes.Status201Created);
    }
}