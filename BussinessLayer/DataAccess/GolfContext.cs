using BussinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.DataAccess
{
    public class GolfContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Hole> Holes { get; set; }
        public DbSet<Player> Players { get; set; }

        public GolfContext()
        {

        }
    }
}
