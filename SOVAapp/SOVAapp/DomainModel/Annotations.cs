using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.DomainModel
{
   public class Annotations
    {
        [Key]
        public int MarkedPostId { get; set; }
        public string Annotation { get; set; }
        public Marking Marking { get; set; }
    }
}
