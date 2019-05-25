using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Course
    {

        [Key]
        public int CourseId { get; set; }
        public String CourseName { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public String Day { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
        public double Grade { get; set; }
    }
}