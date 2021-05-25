using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballClubsManager.Models;
using FootballClubsManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FootballClubsManager.Infrastructure.Repositories
{

    public class FootballClubsRepository : IFootbalClubsRepository
    {
        private FootballClubsManagerContext _context;

        public FootballClubsRepository(FootballClubsManagerContext clubContext)
        {
            this._context = clubContext;
        }

        public IEnumerable<FootballClub> GetClubs()
        {
            return _context.FootballClubs.ToList();
        }

        public FootballClub GetClubById(int id)
        {
            return _context.FootballClubs.Find(id);
        }

        public FootballClub GetClubByName(string name)
        {
            return _context.FootballClubs.Find(name);
        }

        public void InsertClub(FootballClub club)
        {
            _context.FootballClubs.Add(club);
            Save();
              
        }

        public void DeleteClub(int clubId)
        {
            var club = _context.FootballClubs.Find(clubId);
            _context.FootballClubs.Remove(club);
        }

        public void UpdateClub(FootballClub club)
        {
            _context.Entry(club).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}