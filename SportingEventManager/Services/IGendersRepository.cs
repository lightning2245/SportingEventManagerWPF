using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public interface IGendersRepository
    {
        Task<List<Gender>> GetGendersAsync();
        Task<Gender> GetGenderAsync(int id);
        Task<Gender> AddGenderAsync(Gender gender);
        Task<Gender> UpdateGenderAsync(Gender gender);
        Task DeleteGenderAsync(int genderId);
    }
}
