using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public class SchedulesRepository : ISchedulesRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public Task<List<Schedule>> GetSchedulesAsync()
        {
            return _context.Schedules.ToListAsync();
        }

        public Task<Schedule> GetScheduleAsync(int id)
        {
            return _context.Schedules.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Schedule> AddScheduleAsync(Schedule schedule)
        {
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> UpdateScheduleAsync(Schedule schedule)
        {
            if (!_context.Schedules.Local.Any(a => a.Id == schedule.Id))
            {
                _context.Schedules.Attach(schedule);
            }
            _context.Entry(schedule).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return schedule;

        }

        public async Task DeleteScheduleAsync(int scheduleId)
        {
            var schedule = _context.Schedules.FirstOrDefault(a => a.Id == scheduleId);
            if (schedule != null)
            {
                _context.Schedules.Remove(schedule);
            }
            await _context.SaveChangesAsync();
        }
    }
}
