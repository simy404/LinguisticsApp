using System.Net;
using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Application.RequestParameters;
using LinguisticsAPI.Application.RequestParameters.Common;
using LinguisticsAPI.Application.Services;
using LinguisticsAPI.Application.ViewModel;
using LinguisticsAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IAuthorWriteRepository _writeRepository;
		private readonly IAuthorReadRepository _readRepository;
		private readonly IFileService _fileService;

		public AuthorController(IAuthorWriteRepository writeRepository, IAuthorReadRepository readRepository,
			IFileService fileService)
		{
			_writeRepository = writeRepository;
			_readRepository = readRepository;
			_fileService = fileService;
		}

		[HttpGet]
		[ProducesResponseType(typeof(PagedResponse<Author>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(IEnumerable<PagedResponse<Author>>), StatusCodes.Status400BadRequest)]
		public ActionResult Get([FromQuery] Pagination p)
		{
			if (p.PageSize <= 0 || p.PageNumber <= 0)
			{
				return BadRequest();
			}

			var totalCount = _readRepository.GetAll(false).Count();
			var authors = _readRepository.GetAll(false)
				.Skip((p.PageNumber - 1) * p.PageSize)
				.Take(p.PageSize)
				.ToList();

			var totalPages = (int)Math.Ceiling(totalCount / (double)p.PageSize);

			var response = new PagedResponse<Author>
			{
				TotalCount = totalCount,
				PageNumber = p.PageNumber,
				PageSize = p.PageSize,
				Items = authors,
				PreviousPageUrl = p.PageNumber > 1
					? Url.Action(nameof(Get), new { pageNumber = p.PageNumber - 1, p.PageSize })
					: null,
				NextPageUrl = p.PageNumber < totalPages
					? Url.Action(nameof(Get), new { pageNumber = p.PageNumber + 1, p.PageSize })
					: null
			};

			return Ok(response);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(Author), StatusCodes.Status200OK)]
		public async Task<ActionResult> Get(string id)
		{
			var author = await _readRepository.GetById(id, false);
			if (author is null)
			{
				return NotFound();
			}

			return Ok(author);
		}

		[HttpPost]
		[ProducesResponseType(typeof(AuthorCreateVM), StatusCodes.Status201Created)]
		public async Task<IActionResult> Create([FromBody] AuthorCreateVM author)
		{
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
		public async Task<IActionResult> Delete(string id)
		{
			await _writeRepository.Remove(id);

			await _writeRepository.SaveAsync();
			return Ok();
		}

		[HttpPost("[Action]")]
		public async Task<IActionResult> Upload(string id, IFormFile file)
		{
			var author = await _readRepository.GetById(id, false);
			if (author is null)
			{
				return NotFound();
			}

			var result = await _fileService.UploadFileAsync(new FormFileCollection { file }, "resources/authors");
			// if (result == HttpStatusCode.OK)
			// {
			// 	author.ImagePath = file.FileName;
			// 	await _writeRepository.SaveAsync();
			// 	return Ok();
			// }

			return StatusCode((int)result);
		}
	}
}
