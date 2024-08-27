using LinguisticsAPI.Application.Abstraction.Auth;
using LinguisticsAPI.Application.Abstraction.Pagination;
using LinguisticsAPI.Application.Abstraction.Storage;
using LinguisticsAPI.Infrastructure.Services;
using LinguisticsAPI.Infrastructure.Services.Auth;
using LinguisticsAPI.Infrastructure.Services.Pagination;
using Microsoft.Extensions.DependencyInjection;

namespace LinguisticsAPI.Infrastructure;

public static class ServiceRegistration
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IStorageService, StorageService>();
        services.AddScoped<IPaginationService, PaginationService>();
        services.AddScoped<IAuthService, AuthService>();
    }
    
    public static void AddStorage<T> (this IServiceCollection services) where T : class, IStorage
    {
        services.AddScoped<IStorage, T>();
    }
}