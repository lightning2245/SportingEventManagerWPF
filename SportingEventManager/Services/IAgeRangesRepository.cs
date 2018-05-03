using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public interface IAgeRangesRepository
    {
        Task<List<AgeRange>> GetAgeRangesAsync();
        Task<AgeRange> GetAgeRangeAsync(int id);
        Task<AgeRange> AddAgeRangeAsync(AgeRange ageRange);
        Task<AgeRange> UpdateAgeRangeAsync(AgeRange ageRange);
        Task DeleteAgeRangeAsync(int ageRangeId);
    }
}
