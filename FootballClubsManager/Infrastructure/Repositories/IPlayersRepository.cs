using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballClubsManager.Models;

namespace FootballClubsManager.Infrastructure.Repositories
{
    public interface IPlayersRepository
    {
        IEnumerable<Player> GetPlayers();
        Player GetPlayerById(int playerId);
        IEnumerable<Player> GetPlayersByClubName(string clubName);
        void InsertPlayer(Player player);
        void DeletePlayer(int playerId);
        void UpdatePlayer(Player player);
    }
}
