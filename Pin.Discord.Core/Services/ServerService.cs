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
    public class ServerService : IServerService
    {
        private readonly ApplicationDbContext _context;

        public ServerService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<Server>> GetAsync()
        {
            return await _context.Servers.ToListAsync();
        }

        public async Task<Server> GetServerByServerIdAsync(int serverId)
        {
            return await _context.Servers.FindAsync(serverId);
        }
        public async Task<IEnumerable<Server>> GetServersForUserAsync(int userId)
        {
            return await _context.ServerMembers
                .Where(sm => sm.UserId == userId)
                .Select(sm => sm.Server)
                .ToListAsync();
        }

        public async Task AddNewServerAsync(string serverName, int userId)
        {
            try
            {
                var newServer = new Server
                {
                    ServerName = serverName
                };

                _context.Servers.Add(newServer);
                await _context.SaveChangesAsync();

                var serverMember = new ServerMember
                {
                    ServerId = newServer.Id,
                    UserId = userId,

                };

                _context.ServerMembers.Add(serverMember);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteServerAsync(int serverId)
        {
            try
            {
                var server = _context.Servers.Find(serverId);
                _context.Servers.Remove(server);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task EditServerNameAsync(int serverId, string newName)
        {
            try
            {
                var server = _context.Servers.Find(serverId);
                server.ServerName = newName;
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

        }
        public async Task<IEnumerable<Server>> GetServersUserNotInAsync(int userId)
        {
            var userServerIds = await _context.ServerMembers
                .Where(sm => sm.UserId == userId)
                .Select(sm => sm.ServerId)
                .ToListAsync();

            return await _context.Servers
                .Where(s => !userServerIds.Contains(s.Id))
                .ToListAsync();
        }

        public async Task JoinServerAsync(int serverId, int userId)
        {
            var alreadyMember = await _context.ServerMembers
                .AnyAsync(sm => sm.ServerId == serverId && sm.UserId == userId);

            if (!alreadyMember)
            {
                _context.ServerMembers.Add(new ServerMember
                {
                    ServerId = serverId,
                    UserId = userId
                });
                await _context.SaveChangesAsync();
            }

        }
    }
}
