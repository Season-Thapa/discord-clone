using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Services.State
{
    public class UserState
    {
        public int CurrentUserId { get; set; }
        public bool IsLoggedIn => CurrentUserId > 0;
    }
}
