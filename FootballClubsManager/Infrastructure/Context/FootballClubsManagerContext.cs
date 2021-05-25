using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FootballClubsManager.Models;

namespace FootballClubsManager.Infrastructure.Context
{
    public class FootballClubsManagerContext :  DbContext
    {
        public DbSet<FootballClub> FootballClubs { get; set; }
        public DbSet<Player> Players { get; set; }

        public FootballClubsManagerContext(DbContextOptions<FootballClubsManagerContext> options) : base(options) { }

        public FootballClubsManagerContext() : base() { }

    
    }
}
