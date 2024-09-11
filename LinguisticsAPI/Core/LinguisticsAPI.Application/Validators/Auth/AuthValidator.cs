using FluentValidation;
using LinguisticsAPI.Application.ViewModel.User;

namespace LinguisticsAPI.Application.Validators.Auth;

public class AuthValidator : AbstractValidator<AuthLoginVM>
{
    public AuthValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
    }
}