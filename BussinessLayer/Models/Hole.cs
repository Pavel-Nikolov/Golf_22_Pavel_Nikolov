using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BussinessLayer.Models
{
    public class Hole
    {
        [Key]
        public int ID { get; set; }
        [Range(1, int.MaxValue)]
        public int Number { get; set; }
        [Range(0, int.MaxValue)]
        public int Length { get; set; }
        [Range(0, int.MaxValue)]
        public int Par { get; set; }
        [Required]
        public virtual Course Course { get; set; }

        public override string ToString()
        {
            return $"ID: {ID,-4}|Course Name: {Course.Name,-25}|Number: {Number,-2}|Length: {Length,-3}m|Par: {Par,-2}";
        }
    }
}
