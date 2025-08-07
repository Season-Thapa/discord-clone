using Microsoft.AspNetCore.SignalR;
using Pin.Discord.Core.Entities;

namespace Pin.Discord.Blazor.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(int channelId, string username, string message)
        {
            await Clients.Group($"channel-{channelId}")
                         .SendAsync("ReceiveMessage", username, message);
        }

        public async Task JoinChannel(int channelId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"channel-{channelId}");
        }

        public async Task LeaveChannel(int channelId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"channel-{channelId}");
        }

    }
}
