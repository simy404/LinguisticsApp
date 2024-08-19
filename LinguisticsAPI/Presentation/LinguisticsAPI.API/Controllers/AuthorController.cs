using System.Net;
using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Application.ViewModel;
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
		[ProducesResponseType(typeof(IQueryable<AuthorCreateVM>), StatusCodes.Status201Created)]
		public ActionResult Get()
		{
			return Ok( _readRepository.GetAll(false));
		}
		
		[HttpGet("{id}")]
		[ProducesResponseType(typeof(AuthorCreateVM), StatusCodes.Status201Created)]
		public ActionResult Get(string id)
		{
			return Ok(_readRepository.GetById(id, false));
		}
		
		[HttpPost]
		[ProducesResponseType(typeof(AuthorCreateVM), StatusCodes.Status201Created)]
		public async Task<IActionResult> Create([FromBody] AuthorCreateVM author)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			//TODO: Add AutoMapper
			await _writeRepository.AddAsync(new Author()
				{
					Name = author.Name,
					Bio = author.Bio,
					Email = author.Email
				});
			
			await _writeRepository.SaveAsync();
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] AuthorUpdateVM author)
		{
			 _writeRepository.Update(new Author()
				 {
					 Id = Guid.Parse(author.Id),
					 Name = author.Name,
					 Bio = author.Bio,
					 Email = author.Email
				 });
			 
			await _writeRepository.SaveAsync();
			return Ok((int)HttpStatusCode.OK);
		}
		
		[HttpDelete("{id}")]
		public  async Task<IActionResult> Delete(string id)
		{
			await _writeRepository.Remove(id);
			
			await _writeRepository.SaveAsync();
			return Ok();
		}
	}
}
