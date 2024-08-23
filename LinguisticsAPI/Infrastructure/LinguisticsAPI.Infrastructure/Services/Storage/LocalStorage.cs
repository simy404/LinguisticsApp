using System.Net;
using LinguisticsAPI.Application.Abstraction.Storage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace LinguisticsAPI.Infrastructure.Services.Storage;

public class LocalStorage : ILocalStorage
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IConfiguration _configuration;
    
    public LocalStorage(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
    {
        _webHostEnvironment = webHostEnvironment;
        _configuration = configuration;
    }
    
    public async Task<(HttpStatusCode httpStatusCode, string filePath)> UploadFileAsync(IFormFile? formFile, string path)
    {
        if(formFile is null || formFile.Length == 0)
            return (HttpStatusCode.BadRequest, null);
        try
        {
            //wwwroot/resources/path
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);
            
                string fileExtension = Path.GetExtension(formFile.FileName).ToLower();
                string uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                string filePath = Path.Combine(uploadPath, uniqueFileName);

                await using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(fileStream);
                }

            return (HttpStatusCode.OK, uniqueFileName);
        }
        catch (Exception ex)
        {
            return (HttpStatusCode.InternalServerError, null);
        }
    }

    public Task<HttpStatusCode> DeleteFileAsync(string path, string fileName)
    {   
        var combinePath = Path.Combine(path, fileName);
        if(File.Exists(combinePath))
        {
            File.Delete(combinePath);
            return Task.FromResult(HttpStatusCode.OK);
        }
        return Task.FromResult(HttpStatusCode.NotFound);
    }

    public Task<string> GetFileAsync(string path, string fileName)
        =>  Task.FromResult($"{_configuration["BaseLocalStorageUrl"]}/{path}/{fileName}");
    

    public bool HasFile(string path, string fileName) => File.Exists(Path.Combine(path, fileName));
}