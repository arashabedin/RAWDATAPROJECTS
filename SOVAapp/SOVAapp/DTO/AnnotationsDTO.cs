using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;


namespace DataService.DTO
{
   public class AnnotationsDTO
    {
        public int MarkedPostId { get; set; }
        public String Annotation { get; set; }
        public Marking Marking { get; set; }

        public AnnotationsDTO( int MarkedPostId,  String Annotation , Marking Marking )
        {
            this.MarkedPostId = MarkedPostId;
            this.Annotation = Annotation;
            this.Marking = Marking;
        }
    }
}
