using FluentValidation;
using LinguisticsAPI.Application.ViewModel;

namespace LinguisticsAPI.Application.Validators.Author;

public class ProfilePictureValidator : AbstractValidator<ProfilePictureVM>
{
    private const long MaxFileSize = 1 * 1024 * 1024; // 1MB
    
    public ProfilePictureValidator()
    {
        RuleFor(x => x.File)
            .NotNull().WithMessage("File is required.")
            .DependentRules(() =>
            {
                RuleFor(x => x.File)
                    .Must(file => file.Length > 0).WithMessage("Uploaded file is empty.")
                    .Must(file =>
                    {
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                        var fileExtension = Path.GetExtension(file.FileName).ToLower();
                        return allowedExtensions.Contains(fileExtension);
                    }).WithMessage("Only .jpg and .png files are allowed.")
                    .Must(file =>
                        file.Length <= MaxFileSize).WithMessage($"File size must be less than or equal to {((double)MaxFileSize / (1024 * 1024))} MB.");
            });
    }
}