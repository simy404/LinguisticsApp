using FluentValidation;
using LinguisticsAPI.Application.ViewModel.LinkTopic;

namespace LinguisticsAPI.Application.Validators.LinkTopic;

public class LinkTopicValidator : AbstractValidator<LinkTopicCreateVM>
{
    public LinkTopicValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Title).MaximumLength(100).WithMessage("Title must not exceed 100 characters");
    }
}