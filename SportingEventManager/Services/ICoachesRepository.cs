using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public interface ICoachesRepository
    {
        Task<List<Coach>> GetCoachesAsync();
        Task<Coach> GetCoachAsync(int id);
        Task<Coach> AddCoachAsync(Coach coach);
        Task<Coach> UpdateCoachAsync(Coach coach);
        Task DeleteCoachAsync(int coachId);
    }
}
