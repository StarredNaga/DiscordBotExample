using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace MyConsoleApp.Services;

public class LoggingService
{
    public LoggingService(DiscordSocketClient client, CommandService commandService)
    {
        client.Log += Log;
        commandService.Log += Log;
        client.SlashCommandExecuted += OnSlashCommand;
    }

    private static Task OnSlashCommand(SocketSlashCommand arg)
    {
        Console.WriteLine($"{arg.Data.Name} Executed");
        
        return Task.CompletedTask;
    }

    private static Task Log(LogMessage message)
    {
        if (message.Exception != null)
        {
            Console.WriteLine($"[{message.Severity}] {message.Exception}");
            
            return Task.CompletedTask;
        }
       
        Console.WriteLine($"[{message.Severity}] {message.Message}");
        
        return Task.CompletedTask;
    }
}