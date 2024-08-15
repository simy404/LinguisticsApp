using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{

		[HttpGet]
		public IActionResult GetProducts()
		{
			return Ok("Hello World");
		}
	}
}
