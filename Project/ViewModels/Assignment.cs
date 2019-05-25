using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.ViewModels
{
    public class Assignment
    {
        [Key]
        public int DevoirId { get; set; }
       
        public HttpPostedFileBase File { get; set; }
        public List<Student> Students { get; set; }
        public String StudentEmail { get; set; }
        public List<Course> Courses { get; set; }
        public String  CourseName { get; set; }

    }
}