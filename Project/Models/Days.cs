using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Days
    {
        [Key]
        public int DayId { get; set; }
        public String DayName { get; set; }
    }
}