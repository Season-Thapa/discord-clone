using Microsoft.AspNetCore.SignalR;
using Pin.Discord.Blazor.Models;

namespace Pin.Discord.Blazor.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string toUser,string fromUser, string message)
        {
            await Clients.Client(toUser).SendAsync("ReceiveMessage",fromUser, message);
        }
        public async Task SendMessageToGroup(string groupName, ChatMessage message)
        {
            await Clients.Group(groupName).SendAsync("ReceiveGroupMessage", message);
        }

        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");

        }

        public async Task RemoveFromGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        }

        public string GetConnectionId()
        {
            return Context.ConnectionId;
        }
    }
}
