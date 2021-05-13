using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BussinessLayer.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        [Range(1, int.MaxValue)]
        public int NumberOfHoles { get; set; }
        [Required]
        public virtual ICollection<Hole> Holes { get; set; }
        [Required]
        public virtual ICollection<Player> Players { get; set; }

        public Course()
        {
            Holes = new List<Hole>();
            Players = new List<Player>();

        }

        public override string ToString()
        {
            return $"ID: {ID,-5}|Name: {Name,-20}|Hole#: {NumberOfHoles,-2}|Players: {string.Join(", ", Players.Take(2).Select(x => x.Name)),-40} ...";
        }
    }
}
