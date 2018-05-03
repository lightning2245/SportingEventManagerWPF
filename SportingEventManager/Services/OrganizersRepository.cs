using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public class OrganizersRepository : IOrganizersRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public Task<List<Organizer>> GetOrganizersAsync()
        {
            return _context.Organizers.ToListAsync();
        }

        public Task<Organizer> GetOrganizerAsync(int id)
        {
            return _context.Organizers.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Organizer> AddOrganizerAsync(Organizer organizer)
        {
            _context.Organizers.Add(organizer);
            await _context.SaveChangesAsync();
            return organizer;
        }

        public async Task<Organizer> UpdateOrganizerAsync(Organizer organizer)
        {
            if (!_context.Organizers.Local.Any(a => a.Id == organizer.Id))
            {
                _context.Organizers.Attach(organizer);
            }
            _context.Entry(organizer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return organizer;

        }

        public async Task DeleteOrganizerAsync(int organizerId)
        {
            var organizer = _context.Organizers.FirstOrDefault(a => a.Id == organizerId);
            if (organizer != null)
            {
                _context.Organizers.Remove(organizer);
            }
            await _context.SaveChangesAsync();
        }
    }
}
