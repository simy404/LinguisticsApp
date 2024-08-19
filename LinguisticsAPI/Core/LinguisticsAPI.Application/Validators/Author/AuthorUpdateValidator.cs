using FluentValidation;
using LinguisticsAPI.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinguisticsAPI.Application.Validators.Author
{
	public class AuthorUpdateValidator : AbstractValidator<AuthorUpdateVM>
	{
		public AuthorUpdateValidator()
		{
			RuleFor(x => x.Id)
				.NotEmpty().WithMessage("Id is required.")
				.Must(BeAValidGuid).WithMessage("Id must be a valid GUID."); 

			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("Name is required.") 
				.Length(2, 50).WithMessage("Name must be between 2 and 50 characters."); 

			RuleFor(x => x.Bio)
				.NotEmpty().WithMessage("Bio is required.")
				.MaximumLength(500).WithMessage("Bio must be a maximum of 500 characters.");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("Email is required.")
				.EmailAddress().WithMessage("Invalid email format.");
		}
		
		private bool BeAValidGuid(string id)
		{
			return Guid.TryParse(id, out _);
		}
	}
}

