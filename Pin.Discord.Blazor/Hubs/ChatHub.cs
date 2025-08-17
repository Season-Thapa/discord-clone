using Microsoft.AspNetCore.SignalR;
using Pin.Discord.Blazor.Models;

namespace Pin.Discord.Blazor.Hubs
{
    public class ChatHub : Hub
    {
 
        public async Task SendMessage(int toUserId, int fromUserId, Guid messageId, string message)
        {
            await Clients.User(toUserId.ToString())
                .SendAsync("ReceiveMessage", messageId, fromUserId.ToString(), message);
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
        public async Task AddReaction(Guid messageId, int userId, string emoji, int toUserId)
        {
            await Clients.User(toUserId.ToString())
                .SendAsync("ReceiveReaction", messageId, userId, emoji);
        }
        public async Task AddReactionToGroup(string groupName, Guid messageId, int userId, string emoji)
        {
            await Clients.Group(groupName).SendAsync("ReceiveGroupReaction", messageId, userId, emoji);
        }

    }
}
