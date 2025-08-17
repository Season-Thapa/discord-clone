using Pin.Discord.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Interfaces
{
    public interface IChannelService
    {
        Task<IEnumerable<Channel>> GetAsync();
        Task<IEnumerable<Channel>> GetChannelsByServerIdAsync(int serverId);
        Task<Channel> AddNewChannel(string channelName, int serverId);
        Task DeleteByServerId(int serverId);
    }
}
