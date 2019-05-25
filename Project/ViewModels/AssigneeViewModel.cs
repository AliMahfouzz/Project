using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.ViewModels
{
    public class AssigneeViewModel
    {
        [Key]
        public int AssigneeId { get; set; }

        public Teacher Teacher { get; set; }
        public String TeacherEmail { get; set; }

        public Course Course { get; set; }
        public String CourseName { get; set; }

        //public int CourseId { get; set; }
        public List<Course> Courses { get; set; }

        public List<Teacher> teachers { get; set; }
        public String TeacherId { get; set; }


    }
}