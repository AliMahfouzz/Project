using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class GradeDetail
    {
        [Key]
        public int GradeDetailId { get; set; }
        public List<Grade> Grades { get; set; }
    }
}