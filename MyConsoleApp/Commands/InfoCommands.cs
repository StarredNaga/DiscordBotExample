using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace MyConsoleApp.Commands;

public class InfoCommands : ModuleBase<SocketCommandContext>
{
    //Simple info command
    [Command("info")]
    private async Task Info(SocketGuildUser socketGuildUser = null)
    {
        if (socketGuildUser == null)
        {
            var embed = new EmbedBuilder()
                .WithColor(Color.Orange)
                .WithTitle(Context.User.Username)
                .WithImageUrl(Context.User.GetAvatarUrl())
                .AddField("User ID:", Context.User.Id, true)
                .AddField("Created at", Context.User.CreatedAt, true);

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }
        else
        {
            var embed = new EmbedBuilder()
                .WithColor(Color.Orange)
                .WithTitle(socketGuildUser.Username)
                .WithImageUrl(socketGuildUser.GetAvatarUrl())
                .AddField("User ID:", socketGuildUser.Id, true)
                .AddField("Created at:", socketGuildUser.CreatedAt, true);

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }
    }

}