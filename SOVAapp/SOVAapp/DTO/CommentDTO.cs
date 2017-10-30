using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;
namespace DataService.DTO
{

    public class CommentDTO
    {

        public int CommentId { get; set; }
        public int PostId { get; set; }
        public String CommentText { get; set; }
        public int CommentScore { get; set; }
        public DateTime CommentCreateDate { get; set; }
        public int OwnerUserId { get; set; }

        public virtual PostDTO post { get; set; }
        public virtual UserInfoDTO UserInfo { get; set; }

        public CommentDTO (int CommentId , int PostId ,String CommentText ,int CommentScore ,DateTime CommentCreateDate, int OwnerUserId, PostDTO post , UserInfoDTO UserInfo )

        {
            this.CommentId = CommentId;
            this.CommentText = CommentText;
            this.CommentScore = CommentScore;
            this.CommentCreateDate = CommentCreateDate;
            this.OwnerUserId = OwnerUserId;
            this.post = post;
            this.UserInfo = UserInfo;

        }
    }
}

