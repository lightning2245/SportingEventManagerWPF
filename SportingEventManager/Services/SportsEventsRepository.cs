using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public class SportsEventsRepository : ISportsEventsRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public Task<List<SportsEvent>> GetSportsEventsAsync()
        {
            return _context.SportsEvents.ToListAsync();
        }

        public Task<SportsEvent> GetSportsEventAsync(int id)
        {
            return _context.SportsEvents.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<SportsEvent> AddSportsEventAsync(SportsEvent sportsEvent)
        {
            _context.SportsEvents.Add(sportsEvent);
            await _context.SaveChangesAsync();
            return sportsEvent;
        }

        public async Task<SportsEvent> UpdateSportsEventAsync(SportsEvent sportsEvent)
        {
            if (!_context.SportsEvents.Local.Any(a => a.Id == sportsEvent.Id))
            {
                _context.SportsEvents.Attach(sportsEvent);
            }
            _context.Entry(sportsEvent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return sportsEvent;

        }

        public async Task DeleteSportsEventAsync(int sportsEventId)
        {
            var sportsEvent = _context.SportsEvents.FirstOrDefault(a => a.Id == sportsEventId);
            if (sportsEvent != null)
            {
                _context.SportsEvents.Remove(sportsEvent);
            }
            await _context.SaveChangesAsync();
        }
    }
}
