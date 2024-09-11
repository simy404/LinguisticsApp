using FluentValidation;
using LinguisticsAPI.Application.ViewModel.LinkTopic;

namespace LinguisticsAPI.Application.Validators.LinkTopic;

public class LinkTopicValidator : AbstractValidator<LinkTopicCreateVM>
{
    public LinkTopicValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
        RuleFor(x => x.Links).NotEmpty().WithMessage("Links are required");
    }
}