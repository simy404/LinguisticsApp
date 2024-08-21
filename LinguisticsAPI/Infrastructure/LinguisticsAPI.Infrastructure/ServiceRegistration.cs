using LinguisticsAPI.Application.Abstraction.Storage;
using LinguisticsAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LinguisticsAPI.Infrastructure;

public static class ServiceRegistration
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IStorageService, StorageService>();
    }
    
    public static void AddStorage<T> (this IServiceCollection services) where T : class, IStorage
    {
        services.AddScoped<IStorage, T>();
    }
}