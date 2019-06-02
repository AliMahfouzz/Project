using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Grade
    {
        [Key]
        public int ID { get; set; }
        public double grade { get; set; }
        public Student Student { get; set; }
        public String StudentEmail { get; set; }
        public Course Course { get; set; }
        public String CourseName { get; set; }
    }
}