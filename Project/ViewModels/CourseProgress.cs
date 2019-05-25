using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.ViewModels
{
    public class CourseProgress
    {
        public Material Material { get; set; }

        public List<Course> Courses { get; set; }
       // public int CourseId { get; set; }

        public HttpPostedFileBase file { get; set; }


    }
}