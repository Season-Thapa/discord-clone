using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public Channel Channel { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime CreationTime { get; set; }
        public string MessageContent { get; set; }
    }
}
