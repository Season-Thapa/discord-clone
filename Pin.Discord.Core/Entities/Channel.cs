using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Entities
{
    public class Channel
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int ServerId { get; set; }
        public Server Server { get; set; }
        public List<ReportedMessage> Messages { get; set; }
    }
}
