using System.Net;
using Microsoft.AspNetCore.Http;

namespace LinguisticsAPI.Application.Abstraction.Storage;

public interface IStorage
{
    public Task<(HttpStatusCode httpStatusCode, string filePath)> UploadFileAsync(IFormFile formFile, string path);
    Task<HttpStatusCode> DeleteFileAsync(string path);
    Task<string> GetFileAsync(string path);
    bool HasFile(string path, string fileName);
}