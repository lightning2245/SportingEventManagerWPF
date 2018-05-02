using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public interface ISchedulesRepository
    {
        Task<List<Schedule>> GetSchedulesAsync();
        Task<Schedule> GetScheduleAsync(int id);
        Task<Schedule> AddScheduleAsync(Schedule schedule);
        Task<Schedule> UpdateScheduleAsync(Schedule schedule);
        Task DeleteScheduleAsync(int scheduleId);
    }
}
