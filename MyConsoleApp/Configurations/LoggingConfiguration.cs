using Microsoft.Extensions.DependencyInjection;
using MyConsoleApp.Services;

namespace MyConsoleApp.Configurations;

public static class LoggingConfiguration
{
    public static IServiceCollection UseLogging(this IServiceCollection services)
    {
        services.AddSingleton<LoggingService>();
        
        return services;
    }
}