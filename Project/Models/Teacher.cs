using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Teacher
    {
        [Key]
        [StringLength(128)]
        public String TeacherId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public String TeacherEmail { get; set; }
        public String Address { get; set; }
        public int PhoneNumber { get; set; }

        public String Degree { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
       
    }
}