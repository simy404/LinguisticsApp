using System.Net;
using LinguisticsAPI.Application.Abstraction.Storage;
using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Application.RequestParameters;
using LinguisticsAPI.Application.RequestParameters.Common;
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
		private readonly IStorageService _storageService;

		public AuthorController(IAuthorWriteRepository writeRepository, IAuthorReadRepository readRepository,
			IStorageService storageService)
		{
			_writeRepository = writeRepository;
			_readRepository = readRepository;
			_storageService = storageService;
		}

		[HttpGet]
		[ProducesResponseType(typeof(PagedResponse<AuthorVM>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
		public ActionResult Get([FromQuery] Pagination p)
		{
			var totalCount = _readRepository.GetAll(false).Count();
			var authors = _readRepository.GetAll(false)
				.Skip((p.PageNumber - 1) * p.PageSize)
				.Take(p.PageSize)
				.Select(author => new AuthorVM()
				{
					Id = author.Id.ToString(),
					Name = author.Name,
					Bio = author.Bio,
					Email = author.Email
				}).ToList();

			var totalPages = (int)Math.Ceiling(totalCount / (double)p.PageSize);

			var response = new PagedResponse<AuthorVM>
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
		[ProducesResponseType(typeof(AuthorVM), StatusCodes.Status200OK)]
		public async Task<ActionResult> Get(string id)
		{
			var author = await _readRepository.GetById(id, false);
			if (author is null)
				return NotFound();

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
		[ProducesResponseType(typeof(AuthorVM), StatusCodes.Status200OK)]
		public async Task<IActionResult> Delete(string id)
		{
			var author = await _readRepository.GetById(id, false);
			if (author is null)
				return NotFound();

			await _writeRepository.Remove(id);
			await _writeRepository.SaveAsync();
			return Ok(author);
		}

		[HttpPost("{id}/profile-picture")]
		[Consumes("multipart/form-data")]
		[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
		public async Task<IActionResult> UploadProfilePicture(string id ,[FromForm] ProfilePictureVM profilePicture)
		{
			var result = await _storageService.UploadFileAsync(profilePicture.File, $"users/{id}/profile-picture");

			if (result.httpStatusCode == HttpStatusCode.OK)
			{
				return Ok(result.filePath);
			}
			else
			{
				return BadRequest();
			}
		}
	}

}
