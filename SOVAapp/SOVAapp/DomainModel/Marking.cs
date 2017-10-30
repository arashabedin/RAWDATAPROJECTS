using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataService.DomainModel
{
    public class Marking
    {
        [Key]
        public int MarkedPostId { get; set; }
        public DateTime MarkingDate { get; set; }
        public virtual Post Post { get; set; }
        public  ICollection<Annotations> Annotations;

    }
}
