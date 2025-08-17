using Microsoft.EntityFrameworkCore;
using Pin.Discord.Core.Data;
using Pin.Discord.Core.Entities;
using Pin.Discord.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Services
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;
        public MessageService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task ReportMessageAsync(int reporterId, int offenderId, string message)
        {
            var reportedMessage = new ReportedMessage
            {
                Content = message,
                ReporterId = reporterId,
                OffenderId = offenderId,
                ReportedAt = DateTime.Now,
            };
            await _context.ReportedMessages.AddAsync(reportedMessage);
            await _context.SaveChangesAsync();
        }
    }

     

    

    
}
