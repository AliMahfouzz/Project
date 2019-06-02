using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class AttendanceDetail
    {
        [Key]
        public int AttendanceDetailId { get; set; }
        public List<Attendance> attendances { get; set; }
    }
}