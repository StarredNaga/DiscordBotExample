using System.Reflection;
using Discord.Interactions;
using Discord.WebSocket;

namespace MyConsoleApp.SlashCommands;

public class SlashCommandHandler
{
    public SlashCommandHandler(DiscordSocketClient client, IServiceProvider services, InteractionService interactionService)
    {
        _client = client;
        _services = services;
        _interaction = interactionService;
    }
    
    private readonly IServiceProvider _services;
    private readonly DiscordSocketClient _client;
    private readonly InteractionService _interaction;

    public void Initialize()
    {
        _client.Ready += OnClientReady;
        
        //_client.SlashCommandExecuted += CommandExecuted;
    }

    /*
    private async Task CommandExecuted(SocketSlashCommand arg)
    {
        //TODO: Some logic here
    }
    */

    private async Task OnClientReady()
    {
        _client.Ready -= OnClientReady;
        
        //Initialize slash commands
        await _interaction.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        await _interaction.RegisterCommandsGloballyAsync(true);
        
        //Handling Interaction
        _client.InteractionCreated += OnInternation;
    }

    private async Task OnInternation(SocketInteraction arg)
    {
        var ctx = new SocketInteractionContext(_client, arg);
        
        //Create command context and execute it
        await _interaction.ExecuteCommandAsync(ctx, _services);
    }
}