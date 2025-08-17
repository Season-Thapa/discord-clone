using Microsoft.EntityFrameworkCore;
using Pin.Discord.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Server>().HasData(new Server { Id = 1, ServerName = "test" });
            modelBuilder.Entity<Channel>().HasData(
                new Channel { Id = 1, ChannelName = "general", ServerId = 1 },
                new Channel { Id = 2, ChannelName = "announcements", ServerId = 1 },
                new Channel { Id = 3, ChannelName = "fun", ServerId = 1 });
        }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<ReportedMessage> ReportedMessages { get; set; }
        public DbSet<Server> Servers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ServerMember> ServerMembers { get; set; }
    }
}
