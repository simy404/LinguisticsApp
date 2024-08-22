using System.Net;
using LinguisticsAPI.Application.Abstraction.Storage;
using Microsoft.AspNetCore.Http;

namespace LinguisticsAPI.Infrastructure.Services;

public class StorageService : IStorageService
{
    private readonly IStorage _storage;
    
    public StorageService(IStorage storage)
    {
        _storage = storage;
    }
    
    public string StorageName { get => _storage.GetType().Name; }

    public Task<(HttpStatusCode, string)> UploadFileAsync(IFormFile file, string path)
        => _storage.UploadFileAsync(file, path);
    
    public Task<HttpStatusCode> DeleteFileAsync(string path, string fileName)
        => _storage.DeleteFileAsync(path, fileName);

    public Task<IFormFile> GetFileAsync(string path, string fileName)
        => _storage.GetFileAsync(path, fileName);

    public bool HasFile(string path, string fileName)
        => _storage.HasFile(path, fileName);

}