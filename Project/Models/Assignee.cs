using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Assignee
    {
        [Key]
        public int AssigneeId { get; set; }
      
        public Teacher Teacher { get; set; }
        public String TeacherEmail { get; set; }

        public Course Course { get; set; }
        public String CourseName { get; set; }



    }
}