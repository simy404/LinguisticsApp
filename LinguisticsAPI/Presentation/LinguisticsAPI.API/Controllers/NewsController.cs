using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly IMapper _mapper;
    
    public NewsController(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    
}