using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using MyConsoleApp.SlashCommands;

namespace MyConsoleApp.Configurations;

public static class SlashCommandsConfiguration
{
    public static IServiceCollection UseSlashCommands(this IServiceCollection services)
    {
        var  interactionServiceConfig = new InteractionServiceConfig()
        {
            //TODO: Add configurations for interaction service
        };

        services
            .AddSingleton<InteractionService>(x =>
                new InteractionService(x.GetRequiredService<DiscordSocketClient>(), interactionServiceConfig))
            .AddSingleton<SlashCommandHandler>();
        
        return services;
    }
}