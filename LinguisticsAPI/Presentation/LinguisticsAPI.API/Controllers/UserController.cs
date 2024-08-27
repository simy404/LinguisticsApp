using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using LinguisticsAPI.Application.ViewModel.User;
using LinguisticsAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;

namespace LinguisticsAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly UserManager<AppUser> _userManager;
	private readonly IMapper _mapper;

	public UserController(UserManager<AppUser> userManager, IMapper mapper)
	{
		_userManager = userManager;
		_mapper = mapper;
	}

	[HttpPost]
	public async Task<IActionResult> Create([FromBody] UserCreateVM user)
	{
		IdentityResult result = await _userManager.CreateAsync(_mapper.Map<AppUser>(user), user.Password);

		return result.Succeeded ? StatusCode(StatusCodes.Status201Created) : BadRequest(result.Errors);
	}

}

