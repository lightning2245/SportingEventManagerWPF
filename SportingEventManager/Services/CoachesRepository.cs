using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public class CoachesRepository : ICoachesRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public Task<List<Coach>> GetCoachesAsync()
        {
            return _context.Coaches.ToListAsync();
        }

        public Task<Coach> GetCoachAsync(int id)
        {
            return _context.Coaches.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Coach> AddCoachAsync(Coach coach)
        {
            _context.Coaches.Add(coach);
            await _context.SaveChangesAsync();
            return coach;
        }

        public async Task<Coach> UpdateCoachAsync(Coach coach)
        {
            if (!_context.Coaches.Local.Any(a => a.Id == coach.Id))
            {
                _context.Coaches.Attach(coach);
            }
            _context.Entry(coach).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return coach;

        }

        public async Task DeleteCoachAsync(int coachId)
        {
            var coach = _context.Coaches.FirstOrDefault(a => a.Id == coachId);
            if (coach != null)
            {
                _context.Coaches.Remove(coach);
            }
            await _context.SaveChangesAsync();
        }
    }
}
