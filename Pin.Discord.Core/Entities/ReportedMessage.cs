using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Entities
{
    public class ReportedMessage
    {
        public int Id { get; set; }    
        public int ReporterId { get; set; }   
        public int OffenderId { get; set; }   
        public string Content { get; set; }   
        public DateTime ReportedAt { get; set; }
        public int? ChannelId { get; set; }
    }
}
