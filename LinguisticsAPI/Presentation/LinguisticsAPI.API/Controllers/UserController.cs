using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
	}
	
	public Task<IActionResult> Create([FromBody] UserCreateVM user)
	{
		return Ok();
	}

}
