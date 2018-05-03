using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public class GendersRepository : IGendersRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public Task<List<Gender>> GetGendersAsync()
        {
            return _context.Genders.ToListAsync();
        }

        public Task<Gender> GetGenderAsync(int id)
        {
            return _context.Genders.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Gender> AddGenderAsync(Gender gender)
        {
            _context.Genders.Add(gender);
            await _context.SaveChangesAsync();
            return gender;
        }

        public async Task<Gender> UpdateGenderAsync(Gender gender)
        {
            if (!_context.Genders.Local.Any(a => a.Id == gender.Id))
            {
                _context.Genders.Attach(gender);
            }
            _context.Entry(gender).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return gender;

        }

        public async Task DeleteGenderAsync(int genderId)
        {
            var gender = _context.Genders.FirstOrDefault(a => a.Id == genderId);
            if (gender != null)
            {
                _context.Genders.Remove(gender);
            }
            await _context.SaveChangesAsync();
        }
    }
}
