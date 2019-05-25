using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public Student Student { get; set; }
        public String StudentEmail { get; set; }
        public Parent Parent { get; set; }
        public String ParentEmail { get; set; }
        public Teacher Teacher { get; set; }
        public String TeacherEmail { get; set; }

        public Course Course { get; set; }
        public String CourseName { get; set; }
    }
}