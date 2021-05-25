using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballClubsManager.Models;

namespace FootballClubsManager.Infrastructure.Repositories
{
    public interface IFootbalClubsRepository
    {
        IEnumerable<FootballClub> GetClubs();
        FootballClub GetClubById(int clubId);
        FootballClub GetClubByName(string name);
        void InsertClub(FootballClub club);
        void DeleteClub(int clubId);
        void UpdateClub(FootballClub club);

    }
}
