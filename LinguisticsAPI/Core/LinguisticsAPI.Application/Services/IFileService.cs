using System.Net;
using Microsoft.AspNetCore.Http;

namespace LinguisticsAPI.Application.Services;

public interface IFileService
{
     Task<HttpStatusCode> UploadFileAsync(IFormFileCollection files, string path); 
     Task<string> GetFileAsync(string path);
}