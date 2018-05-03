using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public class SportsRepository : ISportsRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public Task<List<Sport>> GetSportsAsync()
        {
            return _context.Sports.ToListAsync();
        }

        public Task<Sport> GetSportAsync(int id)
        {
            return _context.Sports.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Sport> AddSportAsync(Sport sport)
        {
            _context.Sports.Add(sport);
            await _context.SaveChangesAsync();
            return sport;
        }

        public async Task<Sport> UpdateSportAsync(Sport sport)
        {
            if (!_context.Sports.Local.Any(a => a.Id == sport.Id))
            {
                _context.Sports.Attach(sport);
            }
            _context.Entry(sport).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return sport;

        }

        public async Task DeleteSportAsync(int sportId)
        {
            var sport = _context.Sports.FirstOrDefault(a => a.Id == sportId);
            if (sport != null)
            {
                _context.Sports.Remove(sport);
            }
            await _context.SaveChangesAsync();
        }
    }
}
