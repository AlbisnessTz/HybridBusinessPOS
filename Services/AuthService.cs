using System;
using System.Threading.Tasks;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;

namespace HybridBusinessPOS.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(string username, string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User { Username = username, PasswordHash = hashedPassword };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;
            return user;
        }
    }
}