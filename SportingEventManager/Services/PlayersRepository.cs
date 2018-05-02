using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportingEventManager.Data;

namespace SportingEventManager.Services
{
    public class PlayersRepository : IPlayersRepository
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public Task<List<Player>> GetPlayersAsync()
        {
            return _context.Players.ToListAsync();
        }

        public Task<Player> GetPlayerAsync(int id)
        {
            return _context.Players.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Player> AddPlayerAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<Player> UpdatePlayerAsync(Player player)
        {
            if (!_context.Players.Local.Any(a => a.Id == player.Id))
            {
                _context.Players.Attach(player);
            }
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return player;

        }

        public async Task DeletePlayerAsync(int playerId)
        {
            var player = _context.Players.FirstOrDefault(a => a.Id == playerId);
            if (player != null)
            {
                _context.Players.Remove(player);
            }
            await _context.SaveChangesAsync();
        }
    }
}
