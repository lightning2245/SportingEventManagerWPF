using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public class AgeRangesRepository : IAgeRangesRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public Task<List<AgeRange>> GetAgeRangesAsync()
        {
            return _context.AgeRanges.ToListAsync();
        }

        public Task<AgeRange> GetAgeRangeAsync(int id)
        {
            return _context.AgeRanges.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<AgeRange> AddAgeRangeAsync(AgeRange ageRange)
        {
            _context.AgeRanges.Add(ageRange);
            await _context.SaveChangesAsync();
            return ageRange;
        }

        public async Task<AgeRange> UpdateAgeRangeAsync(AgeRange ageRange)
        {
            if (!_context.AgeRanges.Local.Any(c => c.Id == ageRange.Id))
            {
                _context.AgeRanges.Attach(ageRange);
            }
            _context.Entry(ageRange).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ageRange;

        }

        public async Task DeleteAgeRangeAsync(int ageRangeId)
        {
            var ageRange = _context.AgeRanges.FirstOrDefault(c => c.Id == ageRangeId);
            if (ageRange != null)
            {
                _context.AgeRanges.Remove(ageRange);
            }
            await _context.SaveChangesAsync();
        }
    }
}
