using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IAuthorWriteRepository _writeRepository;
		private readonly IAuthorReadRepository _readRepository;
		
		public AuthorController(IAuthorWriteRepository writeRepository, IAuthorReadRepository readRepository)
		{
			_writeRepository = writeRepository;
			_readRepository = readRepository;
		}
		
		[HttpGet]
		public ActionResult Get()
		{
			var authors = _readRepository.GetAll();
			return Ok(authors);
		}
		
		[HttpPost]
		[Produces("application/json")]
		[Consumes("application/json")]
		[ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
		public async Task<IActionResult> Create([FromBody] Author author)
		{
			await _writeRepository.AddAsync(author);
			await _writeRepository.SaveAsync();
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] Author author)
		{
			 _writeRepository.Update(author);
			await _writeRepository.SaveAsync();
			return Ok();
		}

		[HttpDelete("{id}")]
		public  async Task<IActionResult> Delete(string id)
		{
			await _writeRepository.Remove(id);
			await _writeRepository.SaveAsync();
			return Ok();
		}
		
		[HttpGet("{id}")]
		public ActionResult Get(string id)
		{
			var author = _readRepository.GetById(id);
			return Ok(author);
		}
		
	}
}
