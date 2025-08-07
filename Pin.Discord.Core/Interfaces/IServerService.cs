using Pin.Discord.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Interfaces
{
    public interface IServerService
    {
        Task<IEnumerable<Server>> GetAsync();
        Task<Server> GetServerByServerIdAsync(int serverId);
        Task AddNewServerAsync(string serverName);
        Task DeleteServerAsync(int serverId);
        Task EditServerNameAsync(int serverId, string newName);
    }
}
