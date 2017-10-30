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
        public MarkingDTO Marking { get; set; }

        public AnnotationsDTO( int MarkedPostId,  String Annotation , MarkingDTO Marking )
        {
            this.MarkedPostId = MarkedPostId;
            this.Annotation = Annotation;
            this.Marking = Marking;
        }
    }
}
