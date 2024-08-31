using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using LinguisticsAPI.Application.Abstraction.Pagination;
using LinguisticsAPI.Application.Abstraction.Storage;
using LinguisticsAPI.Application.Repositories;
using LinguisticsAPI.Application.RequestParameters;
using LinguisticsAPI.Application.RequestParameters.Common;
using LinguisticsAPI.Application.ViewModel;
using LinguisticsAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinguisticsAPI.API.Controllers
{
	[Authorize()]
	[Route("api/[controller]")]
	[ApiController]
	public class AuthorController : ControllerBase
	{
		private readonly IAuthorWriteRepository _writeRepository;
		private readonly IAuthorReadRepository _readRepository;
		private readonly IStorageService _storageService;
		private readonly IPaginationService _paginationService;
		private readonly IMapper _mapper;
		private readonly IConfiguration _configuration;

		public AuthorController(IAuthorWriteRepository writeRepository, IAuthorReadRepository readRepository,
			IStorageService storageService, IPaginationService paginationService, IMapper mapper, IConfiguration configuration)
		{
			_writeRepository = writeRepository;
			_readRepository = readRepository;
			_storageService = storageService;
			_paginationService = paginationService;
			_mapper = mapper;
			_configuration = configuration;
		}

		[HttpGet]
		[ProducesResponseType(typeof(PagedResponse<AuthorVM>), StatusCodes.Status200OK)]
		[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
		public async Task<ActionResult> Get([FromQuery] Pagination p)
		{
			var authors = _readRepository.GetAll(false);
			var response = await _paginationService.GetPagedResponse<AuthorVM, Author>(authors, Url.Action(nameof(Get))!, p);
			
			return Ok(response);
		}

		[HttpGet("{id}")]
		[ProducesResponseType(typeof(AuthorVM), StatusCodes.Status200OK)]
		public async Task<ActionResult> Get(Guid id)
		{
			var author = await _readRepository.GetById(id, false);
			if (author is null)
				return NotFound();

			return Ok(_mapper.Map<AuthorVM>(author));
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		public async Task<IActionResult> Create([FromBody] AuthorCreateVM author)
		{
			await _writeRepository.AddAsync(_mapper.Map<Author>(author));
			await _writeRepository.SaveAsync();
			return StatusCode(StatusCodes.Status201Created);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<IActionResult> Update([FromBody] AuthorUpdateVM authorVM)
		{
			var author = await _readRepository.GetById(authorVM.Id, false);
			if (author is null)
				return NotFound();
			
			_writeRepository.Update(_mapper.Map<Author>(authorVM));
			await _writeRepository.SaveAsync();
			return Ok();
		}

		[HttpDelete("{id}")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> Delete(Guid id)
		{
			var author = await _readRepository.GetById(id, false);
			if (author is null)
				return NotFound();

			await _writeRepository.Remove(id);
			await _writeRepository.SaveAsync();
			return NoContent();;
		}

		[HttpPost("{id}/profile-picture")]
		[Consumes("multipart/form-data")]
		[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
		public async Task<IActionResult> UploadProfilePicture(Guid id, [FromForm] ProfilePictureVM profilePicture)
		{	
			var author = await _readRepository.GetById(id, false);
			if (author is null)
				return NotFound();
			
			var result = await _storageService.UploadFileAsync(profilePicture.File, $"resources/authors-images");
			
			if (result.httpStatusCode == HttpStatusCode.OK)
			{ 
				if(author?.ProfilePicture is not null)
					_storageService.DeleteFileAsync("resources/authors-images", author.ProfilePicture);
				author.ProfilePicture = result.filePath;
				_writeRepository.Update(author);
				_writeRepository.SaveAsync();
				return Ok(result.filePath);
			}
			else
			{
				return BadRequest();
			}
		}
		
		[HttpGet("{id}/profile-picture")]
		public async Task<IActionResult> GetProfilePicture(Guid id)
		{
			var author = await _readRepository.GetById(id, false);
			if (string.IsNullOrEmpty(author?.ProfilePicture))
				return NotFound();
			return Ok(await _storageService.GetFileAsync(_configuration["AuthorImageStoregePath"], author.ProfilePicture));
		}
	}
}
