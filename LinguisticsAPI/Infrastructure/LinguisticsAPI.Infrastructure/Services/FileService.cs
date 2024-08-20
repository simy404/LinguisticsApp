using System.Net;
using LinguisticsAPI.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace LinguisticsAPI.Infrastructure.Services;

public class FileService : IFileService
{   
    private readonly IWebHostEnvironment _webHostEnvironment;
    
    public FileService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task<HttpStatusCode> UploadFileAsync(IFormFileCollection files, string path)
    {
        try
        {
            //wwwroot/resources/path
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            
            foreach (var formFile in files)
            {
                string fileExtension = Path.GetExtension(formFile.FileName).ToLower();
                string uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                string filePath = Path.Combine(uploadPath, uniqueFileName);

                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }
            }

            return HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            return HttpStatusCode.InternalServerError;
        }
    }

    public Task<string> GetFileAsync(string path)
    {
        throw new NotImplementedException();
    }
}