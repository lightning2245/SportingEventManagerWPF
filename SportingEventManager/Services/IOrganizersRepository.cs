using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public interface IOrganizersRepository
    {
        Task<List<Organizer>> GetOrganizersAsync();
        Task<Organizer> GetOrganizerAsync(int id);
        Task<Organizer> AddOrganizerAsync(Organizer organizer);
        Task<Organizer> UpdateOrganizerAsync(Organizer organizer);
        Task DeleteOrganizerAsync(int organizerId);
    }
}
