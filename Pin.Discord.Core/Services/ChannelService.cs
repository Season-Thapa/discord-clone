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
    public class ChannelService
    {
        private readonly ApplicationDbContext _context;
        public ChannelService(ApplicationDbContext context) 
        {
        _context = context;
        }
        public async Task<IEnumerable<Channel>> GetAsync() 
        {   
            return await _context.Channels.ToListAsync();
        }
        public async Task<IEnumerable<Channel>> GetChannelsByServerIdAsync(int serverId)
        {
            return await _context.Channels.Where(c => c.ServerId == serverId).ToListAsync();
              
        }
        public async Task<Channel> GetChannelByChannelId( int channelId)
        {
            return await _context.Channels.FindAsync(channelId);
        }
        public async Task<Channel> AddNewChannel( string channelName,  int serverId)
        {
            Channel newChannel = new Channel { ChannelName = channelName, ServerId = serverId };

            _context.Channels.Add(newChannel);
            await _context.SaveChangesAsync();
            return newChannel;
        }

        public async Task<bool> DeleteChannel(int channelId)
        {
            try
            {
                Channel channel = _context.Channels.Find(channelId);

                _context.Channels.Remove(channel);

                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        public async Task DeleteByServerId(int serverId)
        {
            try
            {
                var channels = _context.Channels.Where(c => c.ServerId == serverId);
                _context.Channels.RemoveRange(channels);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
    }
    
}

