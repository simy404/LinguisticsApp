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

    public async Task<(HttpStatusCode, string)> UploadFileAsync(IFormFile file, string path)
        => await _storage.UploadFileAsync(file, path);
    
    public async Task<HttpStatusCode> DeleteFileAsync(string path, string fileName)
        => await _storage.DeleteFileAsync(path, fileName);

    public async Task<string> GetFileAsync(string path, string fileName)
        => await _storage.GetFileAsync(path, fileName);

    public bool HasFile(string path, string fileName)
        => _storage.HasFile(path, fileName);

}