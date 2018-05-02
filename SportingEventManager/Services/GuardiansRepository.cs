using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public class GuardiansRepository : IGuardiansRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public Task<List<Guardian>> GetGuardiansAsync()
        {
            return _context.Guardians.ToListAsync();
        }

        public Task<Guardian> GetGuardianAsync(int id)
        {
            return _context.Guardians.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Guardian> AddGuardianAsync(Guardian guardian)
        {
            _context.Guardians.Add(guardian);
            await _context.SaveChangesAsync();
            return guardian;
        }

        public async Task<Guardian> UpdateGuardianAsync(Guardian guardian)
        {
            if (!_context.Guardians.Local.Any(a => a.Id == guardian.Id))
            {
                _context.Guardians.Attach(guardian);
            }
            _context.Entry(guardian).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return guardian;

        }

        public async Task DeleteGuardianAsync(int guardianId)
        {
            var guardian = _context.Guardians.FirstOrDefault(a => a.Id == guardianId);
            if (guardian != null)
            {
                _context.Guardians.Remove(guardian);
            }
            await _context.SaveChangesAsync();
        }
    }
}
