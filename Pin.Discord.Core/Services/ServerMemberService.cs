using Microsoft.EntityFrameworkCore;
using Pin.Discord.Core.Data;
using Pin.Discord.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Services
{
    public class ServerMemberService
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
        public async Task<IEnumerable<ServerMember>> GetByServerIdAsync(int serverId)
        {
          return await _context.ServerMembers.Where(s => s.ServerId == serverId).ToListAsync();
            
        }
    
        public async Task DeleteServerMembersByServer(int serverId)
        {
            try
            {
                var serverMembers = _context.ServerMembers.Where(sm => sm.ServerId == serverId);
                _context.ServerMembers.RemoveRange(serverMembers);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
}
