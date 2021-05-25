using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballClubsManager.Models;
using FootballClubsManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FootballClubsManager.Infrastructure.Repositories
{

    public class PlayersRepository : IPlayersRepository
    {
        private FootballClubsManagerContext _context;

        public PlayersRepository(FootballClubsManagerContext clubContext)
        {
            this._context = clubContext;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _context.Players.ToList();
        }

        public Player GetPlayerById(int id)
        {
            return _context.Players.Find(id);
        }

        public IEnumerable<Player> GetPlayersByClubName(string name)
        {
            return _context.Players.Where(x => x.ClubName == name).ToList();
        }

        public void InsertPlayer(Player player)
        {
            _context.Players.Add(player);
            Save();
        }

        public void DeletePlayer(int playerId)
        {
            var player = _context.Players.Find(playerId);
            _context.Players.Remove(player);
        }

        public void UpdatePlayer(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
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