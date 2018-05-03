using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public class LocationsRepository : ILocationsRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public Task<List<Location>> GetLocationsAsync()
        {
            return _context.Locations.ToListAsync();
        }

        public Task<Location> GetLocationAsync(int id)
        {
            return _context.Locations.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Location> AddLocationAsync(Location location)
        {
            _context.Locations.Add(location);
            await _context.SaveChangesAsync();
            return location;
        }

        public async Task<Location> UpdateLocationAsync(Location location)
        {
            if (!_context.Locations.Local.Any(a => a.Id == location.Id))
            {
                _context.Locations.Attach(location);
            }
            _context.Entry(location).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return location;

        }

        public async Task DeleteLocationAsync(int locationId)
        {
            var location = _context.Locations.FirstOrDefault(a => a.Id == locationId);
            if (location != null)
            {
                _context.Locations.Remove(location);
            }
            await _context.SaveChangesAsync();
        }
    }
}
