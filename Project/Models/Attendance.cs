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
        public String Status { get; set; }
        public String Remark { get; set; }
        public Student Student { get; set; }
        public String StudentEmail { get; set; }
        public Course Course { get; set; }
        public String CourseName { get; set; }

    }
}