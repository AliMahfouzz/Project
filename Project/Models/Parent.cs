using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Parent
    {
        [Key]
        public String ParentId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String ParentEmail { get; set; }
        public String Gender { get; set; }
        public int PhoneNumber { get; set; }
        public String Address { get; set; }
    }
}