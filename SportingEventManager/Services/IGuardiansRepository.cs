using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public interface IGuardiansRepository
    {
        Task<List<Guardian>> GetGuardiansAsync();
        Task<Guardian> GetGuardianAsync(int id);
        Task<Guardian> AddGuardianAsync(Guardian guardian);
        Task<Guardian> UpdateGuardianAsync(Guardian guardian);
        Task DeleteGuardianAsync(int guardianId);
    }
}
