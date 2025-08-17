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
        Task<IEnumerable<Server>> GetServersForUserAsync(int userId);
        Task<Server> GetServerByServerIdAsync(int serverId);
        Task<IEnumerable<Server>> GetServersUserNotInAsync(int userId);
        Task JoinServerAsync(int serverId, int userId);
        Task AddNewServerAsync(string serverName, int userId);
        Task EditServerNameAsync(int serverId, string newName);
    }
}
