using LinguisticsAPI.Application.Abstraction;
using LinguisticsAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private readonly IPostRepository _postRepository;
		
		public PostController(IPostRepository postRepository)
		{
			_postRepository = postRepository;
		}

		[HttpGet]
		[ProducesResponseType(typeof(IQueryable<Post>), StatusCodes.Status200OK)]
		public IActionResult GetProducts()
		{
			var Products = _postRepository.GetPosts();
			return Ok(Products);
		}
	}
}
