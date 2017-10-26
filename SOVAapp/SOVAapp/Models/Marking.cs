using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public class Marking
    {
        public int MarkeId { get; set; }
        public int MarkedPostId { get; set; }
        public String MarkingDate { get; set; }
        public virtual Post Post { get; set; }
    }
}
