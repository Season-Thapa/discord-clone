using Microsoft.EntityFrameworkCore;
using Pin.Discord.Core.Data;
using Pin.Discord.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pin.Discord.Core.Services
{
    public class UserService
    {

        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> RegisterAsync(string name, string password)
        {
            if (await _context.Users.AnyAsync(u => u.Name == name))
                return null;

            var user = new User
            {
                Name = name,
                Password = password 
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> AuthenticateAsync(string name, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Name == name && u.Password == password);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Name == name);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
