using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public interface IPlayersRepository
    {
        Task<List<Player>> GetPlayersAsync();
        Task<Player> GetPlayerAsync(int id);
        Task<Player> AddPlayerAsync(Player player);
        Task<Player> UpdatePlayerAsync(Player player);
        Task DeletePlayerAsync(int playerId);
    }
}
