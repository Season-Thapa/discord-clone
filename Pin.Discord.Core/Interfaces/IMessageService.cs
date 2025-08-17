using Pin.Discord.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Interfaces
{
    public interface IMessageService
    {
        Task ReportMessageAsync(int reporterId, int offenderId,string message,int ? channelId = null);

    }
}
