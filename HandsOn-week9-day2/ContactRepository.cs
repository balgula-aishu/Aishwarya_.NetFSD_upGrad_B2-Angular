
using Microsoft.EntityFrameworkCore;
using week9_day2.Data;
using week9_day2.Models;
using week9_day2.Repository;

namespace week9_day2.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetAll()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }
    }
}