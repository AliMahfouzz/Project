using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class DAssignment
    {
        [Key]
        public int AssignemntID { get; set; }

        //public HttpPostedFileBase File { get; set; }
        public DateTime Date { get; set; }
        public Course Course { get; set; }
        public String CourseName { get; set; }
        public String FilePath { get; set; }

        public Student Student { get; set; }
        public String StudentEmail { get; set; }


    }
}