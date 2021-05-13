using BussinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinessLayer.DataAccess.Repositories
{
    public class CourseRepository : IRepository<Course, int>
    {
        private GolfContext context;
        private DbSet<Course> courses;

        public CourseRepository(GolfContext context)
        {
            this.context = context;
            courses = context.Courses;
        }

        public void Create(Course newEntry)
        {
            courses.Add(newEntry);
            context.SaveChanges();
        }

        public void Delete(int key)
        {
            Course toBeDeleted = courses.Find(key);
            if (toBeDeleted == null)
            {
                throw new ArgumentNullException("No such course");
            }
            courses.Remove(toBeDeleted);
            context.SaveChanges();
        }

        public List<Course> Find(string index)
        {
           return courses.Where(x => x.Name == index).ToList();
        }

        public Course Read(int key)
        {
            return courses.Find(key);
        }

        public List<Course> ReadAll()
        {
            return courses.ToList();
        }

        public void Update(Course updatedEntry)
        {
            Course toBeUpdated = courses.Find(updatedEntry.ID);
            if (toBeUpdated == null)
            {
                throw new ArgumentNullException("No such course");
            }

            toBeUpdated.Holes = updatedEntry.Holes;
            toBeUpdated.Name = updatedEntry.Name;
            toBeUpdated.NumberOfHoles = updatedEntry.NumberOfHoles;
            toBeUpdated.Players = updatedEntry.Players;
            context.SaveChanges();
        }
    }
}
