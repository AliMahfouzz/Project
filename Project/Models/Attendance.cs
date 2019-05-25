using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Attendance
    {
        [Key]
        public DateTime date { get; set; }
        public Student Student { get; set; }
        public string StudentID { get; set; }
        public String Email { get; set; }

        public bool Status { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
        public String CourseName { get; set; }

    }
}