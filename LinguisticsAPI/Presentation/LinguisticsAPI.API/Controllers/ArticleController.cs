using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleController : ControllerBase
	{
		//write article crud operations
		private readonly IArticleWriteRepository _writeRepository;
		private readonly IArticleReadRepository _readRepository;
		
		public ArticleController(IArticleWriteRepository writeRepository, IArticleReadRepository readRepository)
		{
			_writeRepository = writeRepository;
			_readRepository = readRepository;
		}
		
		[HttpGet]
		public ActionResult Get()
		{
			var articles = _readRepository.GetAll();
			return Ok(articles);
		}
		
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Article article)
		{
			await _writeRepository.AddAsync(article);
			await _writeRepository.SaveAsync();
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] Article article)
		{
			 _writeRepository.Update(article);
			await _writeRepository.SaveAsync();
			return Ok();
		}

		[HttpDelete("{id}")]
		public  async Task<IActionResult> Delete(string id)
		{
			_writeRepository.Remove(id);
			await _writeRepository.SaveAsync();
			return Ok();
		}
		
		[HttpGet("{id}")]
		public ActionResult Get(string id)
		{
			var article = _readRepository.GetById(id);
			return Ok(article);
		}
		
	}
}
