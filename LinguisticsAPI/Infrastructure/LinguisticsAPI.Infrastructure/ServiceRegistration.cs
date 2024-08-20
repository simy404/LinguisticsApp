using LinguisticsAPI.Application.Services;
using LinguisticsAPI.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LinguisticsAPI.Infrastructure;

public static class ServiceRegistration
{
    public static void AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IFileService, FileService>();
    }
}