using Discord;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;
using MyConsoleApp.Commands;
using RunMode = Discord.Commands.RunMode;

namespace MyConsoleApp.Configurations;

public static class CommandsConfiguration
{
    public static IServiceCollection UseCommands(this IServiceCollection services)
    {
        var commandServiceConfig = new CommandServiceConfig
        {
            CaseSensitiveCommands = false,
            LogLevel = LogSeverity.Info,
            DefaultRunMode = RunMode.Async,
        };

        services
            .AddSingleton(commandServiceConfig)
            .AddSingleton<CommandService>()
            .AddSingleton<CommandHandler>();
        
        return services;
    }
}