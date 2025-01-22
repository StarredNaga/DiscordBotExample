using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using MyConsoleApp.Commands;
using MyConsoleApp.Configurations;
using MyConsoleApp.Services;
using MyConsoleApp.SlashCommands;

namespace MyConsoleApp;

public static class Program
{
    private const string Token = "your token here";
    private static IServiceProvider _provider = null!;
    private static DiscordSocketClient _client = null!;
    
    public static async Task Main(string[] args)
    {
        //Configure services
        ConfigureServices();
        
        //Set client
        _client = _provider.GetRequiredService<DiscordSocketClient>();
        
        //Set logger cuz it doesn't work without initialize (pls help me... ( ; _ ; ))
        var logger = _provider.GetRequiredService<LoggingService>();
        
        //Initialize commands handlers
        var commandHandler = _provider.GetRequiredService<CommandHandler>();
        var slashCommandHandler = _provider.GetRequiredService<SlashCommandHandler>();
        
        //Start handling
        await commandHandler.Initialize();
        slashCommandHandler.Initialize();
        
        //Just start and stop bot
        await StartBot();
        
        Console.ReadKey();
        
        await StopBot();
    }
    
    //Configure services ( : - : )
    private static void ConfigureServices()
    {
        //Change encoding to see emojis in console
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        
        var services = new ServiceCollection();
        
        //Adding services
        services
            .UseDiscordClient()
            .UseCommands()
            .UseSlashCommands()
            .UseLogging();
        
        //Initialize provider
        _provider = services.BuildServiceProvider();
    }
    
    //Starting bot
    private static async Task StartBot()
    {
        await _client.LoginAsync(TokenType.Bot, Token);
        await _client.StartAsync();
    }
    
    //Stop bot
    private static async Task StopBot()
    {
        await _client.StopAsync();
    }
}