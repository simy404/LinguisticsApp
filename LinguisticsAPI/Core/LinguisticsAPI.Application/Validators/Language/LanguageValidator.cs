using FluentValidation;
using LinguisticsAPI.Application.ViewModel.Language;

namespace LinguisticsAPI.Application.Validators.Language;

public class LanguageValidator : AbstractValidator<LanguageCreateVM>
{
    public LanguageValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name field cannot be empty.")
            .Length(2, 100).WithMessage("Name must be between 2 and 100 characters long.");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code field cannot be empty.")
            .Length(2, 10).WithMessage("Code must be between 2 and 10 characters long.")
            .Matches("^[a-zA-Z]{2}$").WithMessage("Code must be exactly two letters.");
    }
}