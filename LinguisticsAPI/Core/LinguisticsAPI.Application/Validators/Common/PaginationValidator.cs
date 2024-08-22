using FluentValidation;
using LinguisticsAPI.Application.RequestParameters;

namespace LinguisticsAPI.Application.Validators.Common;

public class PaginationValidator : AbstractValidator<Pagination>
{
    public PaginationValidator()
    {
        RuleFor(p => p.PageSize)
            .GreaterThan(0).WithMessage("Page size must be greater than 0.");
        
        RuleFor(p => p.PageNumber)
            .GreaterThan(0).WithMessage("Page number must be greater than 0.");
    }
}