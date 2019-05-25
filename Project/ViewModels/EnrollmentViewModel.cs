using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.ViewModels
{
    public class EnrollmentViewModel
    {
        public Student Student { get; set; }
        public String StudentEmail { get; set; }
        public Parent Parent { get; set; }
        public String ParentEmail { get; set; }
        public Teacher Teacher { get; set; }
        public String TeacherEmail { get; set; }

        public Course Course { get; set; }
        public String CourseName { get; set; }
        public List<Student> students { get; set; }
        public List<Enrollment> enrollments { get; set; }
        public List<Parent> parents { get; set; }
        public List<Teacher> teachers { get; set; }
        //public String TeacherEmail { get; set; }
        public List<Course> Courses { get; set; }
        //*public String CourseName { get; set; }
    }
}