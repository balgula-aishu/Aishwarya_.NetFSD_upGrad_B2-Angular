using Microsoft.EntityFrameworkCore;
using UVEMS.DAL.Data;
using UVEMS.DAL.Models;



namespace UVEMS.DAL.Repository
{
    public class SessionService
    {
        private readonly EMSDbContext _context;

        public SessionService(EMSDbContext context)
        {
            _context = context;
        }

        public async Task<List<SessionInfo>> GetAllSessions()
        {
            return await _context.Sessions
                .Include(s => s.Event)
                .Include(s => s.Speaker)
                .ToListAsync();
        }

        public async Task<List<SessionInfo>> GetSessionsByEvent(int eventId)
        {
            return await _context.Sessions
                .Include(s => s.Speaker)
                .Where(s => s.EventId == eventId)
                .ToListAsync();
        }

        public async Task AddSession(SessionInfo model)
        {
            // ✅ Check event exists
            var eventExists = await _context.Events
                .AnyAsync(e => e.EventId == model.EventId);

            if (!eventExists)
                throw new Exception("Invalid EventId");

            // ✅ Validate time
            if (model.SessionStart >= model.SessionEnd)
                throw new Exception("Invalid session time");

            await _context.Sessions.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task AssignSpeaker(int sessionId, int speakerId)
        {
            var session = await _context.Sessions.FindAsync(sessionId);

            if (session != null)
            {
                session.SpeakerId = speakerId;
                await _context.SaveChangesAsync();
            }
        }
    }
}