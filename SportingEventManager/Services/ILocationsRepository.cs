using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public interface ILocationsRepository
    {
        Task<List<Location>> GetLocationsAsync();
        Task<Location> GetLocationAsync(int id);
        Task<Location> AddLocationAsync(Location location);
        Task<Location> UpdateLocationAsync(Location location);
        Task DeleteLocationAsync(int locationId);
    }
}
