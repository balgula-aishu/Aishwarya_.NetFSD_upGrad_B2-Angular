using Microsoft.EntityFrameworkCore;
using UVEMS.DAL.Data;
using UVEMS.DAL.Models;

namespace UVEMS.DAL.Repository
{
    public class UserService
    {
        private readonly EMSDbContext _context;

        public UserService(EMSDbContext context)
        {
            _context = context;
        }

        // ================= REGISTER =================
        public async Task<bool> Register(UserInfo user)
        {
            if (user == null)
                return false;

            var existing = await _context.Users
                .FirstOrDefaultAsync(u => u.EmailId == user.EmailId);

            if (existing != null)
                return false; // Duplicate email

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        // ================= LOGIN =================
        public async Task<UserInfo?> Login(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            return await _context.Users
                .FirstOrDefaultAsync(u => u.EmailId == email && u.Password == password);
        }
    }
}
