using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public interface ISportsRepository
    {
        Task<List<Sport>> GetSportsAsync();
        Task<Sport> GetSportAsync(int id);
        Task<Sport> AddSportAsync(Sport sport);
        Task<Sport> UpdateSportAsync(Sport sport);
        Task DeleteSportAsync(int sportId);
    }
}
