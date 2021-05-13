using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BussinessLayer.Models
{
    public class Player
    {
        [Key]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Range(0, int.MaxValue)]
        public int Score { get; set; }
        [Required]
        public virtual ICollection<Course> FavoriteCourses { get; set; }

        public Player()
        {
            FavoriteCourses = new List<Course>();
        }

        public override string ToString()
        {
            return $"ID: {ID,-4}|Name: {Name,-30}|Score: {Name,-4}points|Favorite Courses: {string.Join(", ",FavoriteCourses.Take(2).Select(x=>x.Name)),-40}...";
        }
    }
}
