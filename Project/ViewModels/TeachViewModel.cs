using Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.ViewModels
{
    public class TeachViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }
        [Required]
        public String Gender { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public String TeacherEmail { get; set; }
        [Required]
        public String Address { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
        [Required]
        public String Degree { get; set; }
       
        public List<Department>Departments { get; set; }
        [Required]
        public int DepartmentId { get; set; }
       
    }
}