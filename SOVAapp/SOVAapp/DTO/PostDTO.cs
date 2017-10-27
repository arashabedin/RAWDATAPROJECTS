using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;

namespace DataService.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int AcceptedAnswerId { get; set; }
        public int LinkPostId { get; set; }
        public int OwneruserId { get; set; }
        public String Body { get; set; }
        public String Title { get; set; }
        public int Score { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public ICollection<Comment> Comments;
        public virtual PostType PostType { get; set; }
        public virtual Marking Marking { get; set; }
        public ICollection<PostTags> PostTags;
        public virtual UserInfo UserInfo { get; set; }


        public PostDTO(int Id, int OwneruserId, String Body, String Title, int Score, DateTime CreationDate, DateTime ClosedDate
            , ICollection<Comment> Comments, PostType PostType, Marking Marking, ICollection<PostTags> PostTags, UserInfo UserInfo)
        {
            this.Id = Id;
            this.OwneruserId = OwneruserId;
            this.Body = Body;
            this.Title = Title;
            this.Score = Score;
            this.CreationDate = CreationDate;
            this.ClosedDate = ClosedDate;
            this.Comments = Comments;
            this.PostType = PostType;
            this.Marking = Marking;
            this.PostTags = PostTags;
            this.UserInfo = UserInfo;
            
        }


    }
}
