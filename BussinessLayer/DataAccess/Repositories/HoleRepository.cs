using BussinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer.DataAccess.Repositories
{
    public class HoleRepository : IRepository<Hole, int>
    {
        private DbSet<Hole> holes;
        private GolfContext context;

        public HoleRepository(GolfContext context)
        {
            this.context = context;
            holes = context.Holes;
        }

        public void Create(Hole newEntry)
        {
            holes.Add(newEntry);
            context.SaveChanges();
        }

        public void Delete(int key)
        {
            Hole hole = holes.Find(key);
            if (hole != null)
            {
                throw new ArgumentNullException("No such hole");
            }
            holes.Remove(hole);
            context.SaveChanges();
        }

        public List<Hole> Find(string index)
        {
            return holes.Where(x => x.Number.ToString() == index).ToList();
        }

        public Hole Read(int key)
        {
            Hole hole = holes.Find(key);
            if (hole != null)
            {
                throw new ArgumentNullException("No such hole");
            }
            return hole;
        }

        public List<Hole> ReadAll()
        {
            return holes.ToList();
        }

        public void Update(Hole updatedEntry)
        {
            Hole hole = holes.Find(updatedEntry.ID);
            if (hole != null)
            {
                throw new ArgumentNullException("No such hole");
            }
            hole.Course = updatedEntry.Course;
            hole.Length = updatedEntry.Length;
            hole.Number = updatedEntry.Number;
            hole.Par = updatedEntry.Par;
            context.SaveChanges();
        }
    }
}
