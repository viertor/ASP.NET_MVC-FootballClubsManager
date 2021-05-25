using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballClubsManager.Infrastructure.Repositories;
using FootballClubsManager.Models;

namespace FootballClubsManager.Services
{
    public class PlayersService : IPlayersService
    {
        private readonly IPlayersRepository _repository;

        public PlayersService(IPlayersRepository playersRepository)
        {
            _repository = playersRepository;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _repository.GetPlayers();
        }

        public IEnumerable<Player> GetPlayersByClubName(string clubName)
        {
            return _repository.GetPlayersByClubName(clubName);
        }

    }
}
