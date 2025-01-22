using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace MyConsoleApp.Configurations;

public static class DiscordClientConfiguration
{
    public static IServiceCollection UseDiscordClient(this IServiceCollection services)
    {
        var discordSocketConfig = new DiscordSocketConfig
        {
            MessageCacheSize = 100,
            LogLevel = LogSeverity.Info,
            GatewayIntents = GatewayIntents.All,
            AlwaysDownloadUsers = true,
        };

        services
            .AddSingleton(discordSocketConfig)
            .AddSingleton<DiscordSocketClient>();
        
        return services;
    }
}