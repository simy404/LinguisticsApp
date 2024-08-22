using Microsoft.AspNetCore.Http;

namespace LinguisticsAPI.Application.ViewModel;

public class ProfilePictureVM
{
    public IFormFile? File { get; set; }
}
