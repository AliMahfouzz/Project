using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Student
    {
        [Key]
        [StringLength(128)]
        public String StudentId { get; set; }
        public String FirstName { get; set; }
        public String FatherName { get; set; }
        public String LastName { get; set; }
        public String Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int HomeNumber { get; set; }
        public String Address { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public String StudentEmail { get; set; }
        public Parent Parent { get; set; }
        public String ParentId { get; set; }
    }
}