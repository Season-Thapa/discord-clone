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
    public class MessageService
    {
        private readonly ApplicationDbContext _context;
        public MessageService(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }
        public async Task<List<Message>> GetMessagesForChannelAsync(int channelId)
        {
            return await _context.Messages
                .Where(m => m.ChannelId == channelId)
                .Include(m => m.User) 
                .OrderBy(m => m.CreationTime)
                .ToListAsync();
        }

        public async Task<Message> AddMessageAsync(int channelId, int userId, string content)
        {
            var message = new Message
            {
                ChannelId = channelId,
                UserId = userId,
                MessageContent = content,
                CreationTime = DateTime.UtcNow
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<bool> DeleteMessageAsync(int messageId, int userId)
        {
            var message = await _context.Messages.FindAsync(messageId);

            if (message == null || message.UserId != userId)
                return false; 

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();
            return true;
        }      
        public async Task<bool> EditMessageAsync(int messageId, int userId, string newContent)
        {
            var message = await _context.Messages.FindAsync(messageId);

            if (message == null || message.UserId != userId)
                return false;

            message.MessageContent = newContent;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
