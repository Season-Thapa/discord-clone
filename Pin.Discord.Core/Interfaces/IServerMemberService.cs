using Microsoft.EntityFrameworkCore;
using Pin.Discord.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Interfaces
{
    public interface IServerMemberService
    {
        Task<IEnumerable<ServerMember>> GetAsync();     
        Task DeleteServerMemberAsync(int serverId, int userId);
    }
}
