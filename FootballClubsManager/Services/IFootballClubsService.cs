using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballClubsManager.Infrastructure.Repositories;
using FootballClubsManager.Models;

namespace FootballClubsManager.Services
{
    public interface IFootballClubsService
    {
        IEnumerable<FootballClub> GetClubs();

        void InsertClub(FootballClub club);
    }
}
