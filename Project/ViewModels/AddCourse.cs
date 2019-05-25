using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.ViewModels
{
    public class AddCourse
    {
        public List<Department> Departments { get; set; }
        public List<Class> Classes { get; set; }
        public List<Days> Days { get; set; }
        public String CourseName { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public Class Class { get; set; }
        public int ClassId { get; set; }
        public String Day { get; set; }
        public String StartTime { get; set; }
        public String EndTime { get; set; }
    }
}