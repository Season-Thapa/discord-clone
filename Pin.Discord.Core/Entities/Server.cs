using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Entities
{
    public class Server
    {
        public int Id { get; set; }
        public string ServerName { get; set; }
        public List<Channel> Channels { get; set; }
    }
}
