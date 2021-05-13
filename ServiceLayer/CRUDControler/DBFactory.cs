using BussinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.CRUDControler
{
    static class DBFactory
    {
        internal static Course GetCourse(object id, object name, object numberOfHoles, List<Hole> holes, List<Player> players)
        {
            return new Course()
            {
                ID = int.Parse(id.ToString()),
                Name = name.ToString(),
                NumberOfHoles = int.Parse(numberOfHoles.ToString()),
                Holes = holes,
                Players = players
            };
        }

        internal static Hole GetHole(object id, object number, object length, object par, Course course)
        {
            return new Hole()
            {
                ID = int.Parse(id.ToString()),
                Number = int.Parse(number.ToString()),
                Length = int.Parse(length.ToString()),
                Par = int.Parse(par.ToString()),
                Course = course
            };
        }

        internal static Player GetPlayer(object id, object name, object score, List<Course> courses)
        {
            return new Player()
            {
                ID = int.Parse(id.ToString()),
                Name = name.ToString(),
                Score = int.Parse(score.ToString()),
                FavoriteCourses = courses
            };
        }
    }
}
