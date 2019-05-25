using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public String  Subject { get; set; }
        public String Description { get; set; }
        public DateTime?  Start { get; set; }
        public DateTime?  End { get; set; }
        public String    ThemeColor { get; set; }

        public bool IsFullDay { get; set; }
    }
}