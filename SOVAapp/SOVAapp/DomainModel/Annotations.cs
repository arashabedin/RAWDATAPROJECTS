using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DomainModel
{
   public class Annotations
    {
        public int MarkedPostId { get; set; }
        public String Annotation { get; set; }
        public Marking Marking { get; set; }
    }
}
