using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;

namespace DataService.DTO
{
    public class MarkingDTO
    {
        public int MarkedPostId { get; set; }
        public DateTime MarkingDate { get; set; }
        public virtual Post Post { get; set; }
        public  ICollection<AnnotationsDTO> Annotations;

        public MarkingDTO(int MarkedPostId , DateTime MarkingDate, Post Post, ICollection<AnnotationsDTO> Annotations)
        {
            this.MarkedPostId = MarkedPostId;
            this.MarkingDate = MarkingDate;
            this.Post = Post;
            this.Annotations = Annotations;


        }

    }
}
