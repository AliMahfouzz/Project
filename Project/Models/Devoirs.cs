using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebGrease.Activities;

namespace Project.Models
{
    public class Devoirs
    {
        [Key]
        public int DevoirId { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose File")]
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
        public Student Student { get; set; }
        public String StudentId { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
        
    }
}