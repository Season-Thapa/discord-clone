using Microsoft.EntityFrameworkCore;
using Pin.Discord.Core.Data;
using Pin.Discord.Core.Entities;
using Pin.Discord.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Services
{
    public class ServerMemberService : IServerMemberService
    {
        private readonly ApplicationDbContext _context;
        public ServerMemberService(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<ServerMember>> GetAsync()
        {
            return await _context.ServerMembers.ToListAsync();
        }
        public async Task DeleteServerMemberAsync(int serverId, int userId)
        {
            var member = await _context.ServerMembers
                .FirstOrDefaultAsync(sm => sm.ServerId == serverId && sm.UserId == userId);
            if (member != null)
            {
                _context.ServerMembers.Remove(member);
                await _context.SaveChangesAsync();
            }
        }
    }
}
