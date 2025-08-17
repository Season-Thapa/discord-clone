using Pin.Discord.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> AuthenticateAsync(string name, string password);
        Task<User> RegisterAsync(string name, string password);
        Task<User> GetByIdAsync(int id);
        Task<List<User>> GetAllUsersAsync();
        Task<IEnumerable<User>> GetOtherUsersAsync(int userId);
    }
}
