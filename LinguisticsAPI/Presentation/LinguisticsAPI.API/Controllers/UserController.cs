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

namespace LinguisticsAPI.API.Controllers
{
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
		
		[HttpPost("[action]")]
		public async Task<IActionResult> Login([FromBody] AuthLoginVM auth)
		{
			var appUser = await _userManager.FindByEmailAsync(auth.Email);
			if (appUser == null)
			{
				return BadRequest("User not found");
			}
			
			var result = await _userManager.CheckPasswordAsync(appUser, auth.Password);
			if (!result)
			{
				return BadRequest("Password is incorrect");
			}
			
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("your_32_character_long_secret_key!"));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, "1234567890"),
				new Claim(JwtRegisteredClaimNames.Name, "John Doe"),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var token = new JwtSecurityToken(
				issuer: "yourIssuer",
				audience: "yourAudience",
				claims: claims,
				expires: DateTime.Now.AddMinutes(120),
				signingCredentials: credentials
			);

			var tokenString = new JwtSecurityTokenHandler().WriteToken(token);			
			return Ok(tokenString);
		}

	}
	

}
