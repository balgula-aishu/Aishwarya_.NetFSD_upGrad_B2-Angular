using Microsoft.EntityFrameworkCore;
using UVEMS.DAL.Data;
using UVEMS.DAL.Models;

namespace UVEMS.DAL.Repository
{
    public class SpeakerService
    {
        private readonly EMSDbContext _context;

        public SpeakerService(EMSDbContext context)
        {
            _context = context;
        }

        public async Task<List<SpeakerDetails>> GetAllSpeakers()
        {
            return await _context.Speakers.ToListAsync();
        }

        public async Task AddSpeaker(SpeakerDetails speaker)
        {
            _context.Speakers.Add(speaker);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpeaker(int id)
        {
            var speaker = await _context.Speakers.FindAsync(id);

            if (speaker != null)
            {
                _context.Speakers.Remove(speaker);
                await _context.SaveChangesAsync();
            }
        }
    }
}
