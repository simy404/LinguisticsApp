using AutoMapper;
using LinguisticsAPI.Application.Abstraction.Auth;
using LinguisticsAPI.Application.ViewModel.User;
using LinguisticsAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IAuthService _authService;
    
    public AuthController(UserManager<AppUser> userManager, IMapper mapper, IAuthService authService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _authService = authService;
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(AuthLoginVM loginVM)
    {
        var user = await _userManager.FindByEmailAsync(loginVM.Email);
        if (user == null)
            return BadRequest(new {message=$"User with '{loginVM.Email}' mail does not exist."});
        
        var result = await _userManager.CheckPasswordAsync(user, loginVM.Password);
        if (!result)
            return BadRequest(new {message="Invalid password."});
        
        var token = _authService.GenerateToken(user);
        return Ok(new {message="User successfully logged in.",TokenResponse=token, id=user.Id});
    }
}