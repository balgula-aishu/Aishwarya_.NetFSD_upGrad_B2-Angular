using Microsoft.EntityFrameworkCore;
using UVEMS.DAL.Data;
using UVEMS.DAL.Models;

namespace UVEMS.DAL.Repository
{
    public class ParticipantService
    {
        private readonly EMSDbContext _context;

        public ParticipantService(EMSDbContext context)
        {
            _context = context;
        }

        // ================= REGISTER EVENT =================
        public async Task RegisterEvent(ParticipantEventDetails data)
        {
            // ✅ VALIDATE EVENT EXISTS (FIX FK ERROR)
            var eventExists = await _context.Events
                .AnyAsync(e => e.EventId == data.EventId);

            if (!eventExists)
                return;

            // ✅ PREVENT DUPLICATE
            var exists = await _context.ParticipantEvents
                .FirstOrDefaultAsync(p =>
                    p.EventId == data.EventId &&
                    p.ParticipantEmailId == data.ParticipantEmailId);

            if (exists != null)
                return;

            _context.ParticipantEvents.Add(data);
            await _context.SaveChangesAsync();
        }

        // ================= GET USER EVENTS =================
        public async Task<List<ParticipantEventDetails>> GetUserEvents(string email)
        {
            return await _context.ParticipantEvents
                .Include(p => p.Event)
                .Where(p => p.ParticipantEmailId == email)
                .ToListAsync();
        }

        // ================= GET ALL EVENTS =================
        public async Task<List<EventDetails>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }
    }
}
