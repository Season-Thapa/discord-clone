using Pin.Discord.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Interfaces
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessagesForChannelAsync(int channelId);
        Task<Message> AddMessageAsync(int channelId, int userId, string content);
        Task<bool> DeleteMessageAsync(int messageId, int userId);
        Task<bool> EditMessageAsync(int messageId, int userId, string newContent);

    }
}
