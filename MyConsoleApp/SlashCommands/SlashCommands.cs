using Discord.Interactions;

namespace MyConsoleApp.SlashCommands;

public class SlashCommands : InteractionModuleBase<SocketInteractionContext>
{
    //Simple slash command
    [SlashCommand("slash", "Slash Command")]
    public async Task Echo(string echo)
    {
        await RespondAsync(echo);

       // await Context.Interaction.Channel.SendMessageAsync(echo);    
    }
}