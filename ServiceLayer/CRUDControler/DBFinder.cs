using BussinessLayer.DataAccess;
using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.CRUDControler
{
    class DBFinder
    {

        private GolfContext context;
        public DBFinder(GolfContext context)
        {
            this.context = context;
        }

        public Course FindCourse(int key)
        {
            Course course = context.Courses.Find(key);
            if (course == null)
            {
                throw new ArgumentNullException("No such course");
            }
            return course;
        }

        public List<Course> FindCourses(int[] keys)
        {
            List<Course> courses = new List<Course>();
            foreach (var key in keys)
            {
                courses.Add(FindCourse(key));
            }
            return courses;
        }

        public List<Hole> FindHoles(int[] keys)
        {
            List<Hole> holes = new List<Hole>();
            foreach (var item in keys)
            {
                Hole newHole = context.Holes.Find(item);
                if (newHole == null)
                {
                    throw new ArgumentNullException("No such hole");
                }
                holes.Add(newHole);
            }
            return holes;
        }

        public List<Player> FindPlayers(int[] keys)
        {
            List<Player> players = new List<Player>();
            foreach (var item in keys)
            {
                Player player = context.Players.Find(item);
                if (player != null)
                {
                    throw new ArgumentNullException("No such hole");
                }
                players.Add(player);
            }
            return players;
        }
    }
}
