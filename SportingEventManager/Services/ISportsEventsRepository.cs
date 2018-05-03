using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public interface ISportsEventsRepository
    {
        Task<List<SportsEvent>> GetSportsEventsAsync();
        Task<SportsEvent> GetSportsEventAsync(int id);
        Task<SportsEvent> AddSportsEventAsync(SportsEvent sportsEvent);
        Task<SportsEvent> UpdateSportsEventAsync(SportsEvent sportsEvent);
        Task DeleteSportsEventAsync(int sportsEventId);
    }
}
