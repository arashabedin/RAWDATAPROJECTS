using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;


namespace DataService.DTO
{
    public class AnswerDTO
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int OwneruserId { get; set; }
        public String Body { get; set; }
        public String Title { get; set; }
        public int Score { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ClosedDate { get; set; }

        public ICollection<CommentDTO> Comments;
        public virtual QuestionDTO QuestionDTO { get; set; }
        public virtual MarkingDTO Marking { get; set; }
        public ICollection<PostTagsDTO> PostTags;
        public virtual UserInfoDTO UserInfo { get; set; }


        public AnswerDTO(int Id, int ParentId, int OwneruserId, String Body, String Title, int Score, DateTime CreationDate, DateTime ClosedDate
            , ICollection<CommentDTO> Comments,QuestionDTO QuestionDTO,PostType PostType, MarkingDTO Marking, ICollection<PostTagsDTO> PostTags, UserInfoDTO UserInfo)
        {
            this.Id = Id;
            this.ParentId = ParentId;
            this.OwneruserId = OwneruserId;
            this.Body = Body;
            this.Title = Title;
            this.Score = Score;
            this.CreationDate = CreationDate;
            this.ClosedDate = ClosedDate;
            this.Comments = Comments;
            this.QuestionDTO = QuestionDTO;
            this.Marking = Marking;
            this.PostTags = PostTags;
            this.UserInfo = UserInfo;

        }


    }
}
