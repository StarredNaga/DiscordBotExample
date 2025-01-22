using System.Reflection;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace MyConsoleApp.Commands;

public class CommandHandler
{
    public CommandHandler(CommandService commands, DiscordSocketClient client, IServiceProvider services)
    {
        _commands = commands;
        _client = client;
        _services = services;
    }
    
    private readonly CommandService _commands;
    private readonly DiscordSocketClient _client;
    private readonly IServiceProvider _services;
    
    //Initialize handler
    public async Task Initialize()
    {
        _client.MessageReceived += HandleCommand;
        _commands.CommandExecuted += OnCommandExecuted;
        
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
    }
    
    //Handling commands executing
    private async Task OnCommandExecuted(Optional<CommandInfo> commandInfo, ICommandContext commandContext, IResult result)
    {
        if (result.IsSuccess)
        {
            //TODO: Bad result handling
            return;
        }

        await commandContext.Channel.SendMessageAsync(result.ErrorReason);
    }
    
    //Handling commands
    private async Task HandleCommand(SocketMessage messageParam)
    {
        if (!(messageParam is SocketUserMessage message)) return;
        if (message.Source != MessageSource.User) return;

        var argPos = 0;
        
        if (!message.HasStringPrefix("!", ref argPos) && !message.HasMentionPrefix(_client.CurrentUser, ref argPos)) return;

        var context = new SocketCommandContext(_client, message);
        await _commands.ExecuteAsync(context, argPos, _services);
    }

}