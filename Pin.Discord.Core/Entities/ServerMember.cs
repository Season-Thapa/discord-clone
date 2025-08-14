using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Entities
{
    public class ServerMember
    {
        public int Id { get; set; }
        public int ServerId { get; set; }
        public Server Server { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
