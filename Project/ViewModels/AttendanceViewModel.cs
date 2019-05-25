using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.ViewModels
{
    public class AttendanceViewModel
    {
        public List<Student> students { get; set; }
        public List<Course> courses { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}