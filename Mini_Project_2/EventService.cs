using Microsoft.EntityFrameworkCore;
using UVEMS.DAL.Data;
using UVEMS.DAL.Models;

namespace UVEMS.DAL.Repository
{
    public class EventService
    {
        private readonly EMSDbContext _context;

        public EventService(EMSDbContext context)
        {
            _context = context;
        }

        // ✅ Get All Events
        public async Task<List<EventDetails>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        // ✅ Get Event By Id
        public async Task<EventDetails> GetEventById(int id)
        {
            return await _context.Events.FindAsync(id);
        }
        // ✅ Add Event
        public async Task AddEvent(EventDetails eventDetails)
        {
            _context.Events.Add(eventDetails);
            await _context.SaveChangesAsync();
        }

        // ✅ Update Event
        public async Task UpdateEvent(EventDetails eventDetails)
        {
            _context.Events.Update(eventDetails);
            await _context.SaveChangesAsync();
        }

        // ✅ Delete Event
        public async Task DeleteEvent(int id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev != null)
            {
                _context.Events.Remove(ev);
                await _context.SaveChangesAsync();
            }
        }

        // ✅ Get Events by Category
        public async Task<List<EventDetails>> GetByCategory(string category)
        {
            return await _context.Events
                .Where(e => e.EventCategory == category)
                .ToListAsync();
        }
    }
}
