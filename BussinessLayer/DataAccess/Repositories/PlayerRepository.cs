using BussinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer.DataAccess.Repositories
{
    public class PlayerRepository : IRepository<Player, int>
    {
        private GolfContext context;
        private DbSet<Player> players;

        public PlayerRepository(GolfContext context)
        {
            this.context = context;
            players = context.Players;
        }

        public void Create(Player newEntry)
        {
            players.Add(newEntry);
            context.SaveChanges();
        }

        public void Delete(int key)
        {
            Player player = players.Find(key);
            if (player != null)
            {
                throw new ArgumentNullException("No such player");
            }
            players.Remove(player);
            context.SaveChanges();
        }

        public List<Player> Find(string index)
        {
            return players.Where(x => x.Name == index).ToList();
        }

        public Player Read(int key)
        {
            Player player = players.Find(key);
            if (player != null)
            {
                throw new ArgumentNullException("No such player");
            }
            return player;
        }

        public List<Player> ReadAll()
        {
            return players.ToList();
        }

        public void Update(Player updatedEntry)
        {
            Player player = players.Find(updatedEntry.ID);
            if (player != null)
            {
                throw new ArgumentNullException("No such player");
            }
            player.FavoriteCourses = updatedEntry.FavoriteCourses;
            player.Name = updatedEntry.Name;
            player.Score = updatedEntry.Score;
            context.SaveChanges();
        }
    }
}
