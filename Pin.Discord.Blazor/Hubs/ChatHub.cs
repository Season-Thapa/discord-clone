using Microsoft.AspNetCore.SignalR;
using Pin.Discord.Blazor.Models;
using Pin.Discord.Core.Entities;

namespace Pin.Discord.Blazor.Hubs
{
    public class ChatHub : Hub
    {        
        public async Task SendMessage(string user,string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user,message);
        }
 

    }
}
//private static readonly Dictionary<string, List<ChatMessage>> _channelMessages = new();
//public async Task SendMessageToGroup(string groupName, ChatMessage message)
//{
//    if (!_channelMessages.ContainsKey(groupName))
//        _channelMessages[groupName] = new List<ChatMessage>();
//    await Clients.Group(groupName).SendAsync("ReceiveGroupMessage",message);
//}

//public async Task AddToGroup(string groupName)
//{
//    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
//    await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");

//}

//public async Task RemoveFromGroup(string groupName)
//{
//    await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

//}

//public string GetConnectionId()
//{
//    return Context.ConnectionId;
//}