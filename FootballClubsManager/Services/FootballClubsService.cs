using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballClubsManager.Infrastructure.Repositories;
using FootballClubsManager.Models;

namespace FootballClubsManager.Services
{
    public class FootballClubsService : IFootballClubsService
    {
        private readonly IFootbalClubsRepository _clubsRepository;
        private readonly IPlayersRepository _playersRepository;

        public FootballClubsService(IFootbalClubsRepository footbalClubRepository, IPlayersRepository playersRepository)
        {
            _clubsRepository = footbalClubRepository;
            _playersRepository = playersRepository;
        }

        public IEnumerable<FootballClub> GetClubs()
        {
            var clubs = _clubsRepository.GetClubs();
            foreach(var club in clubs)
            {
                club.Players = _playersRepository.GetPlayersByClubName(club.Name).ToList();
            }
            return clubs;
        }

        public void InsertClub(FootballClub club)
        {
            _clubsRepository.InsertClub(club);
        }




    }
}
