using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.ViewModels
{
    public class AttendanceProgress
    {
        public DAssignment assignment { get; set; }

        public List<Course> Courses { get; set; }
        public List<Student> Students { get; set; }
       // public int CourseId { get; set; }

        public HttpPostedFileBase file { get; set; }


    }
}