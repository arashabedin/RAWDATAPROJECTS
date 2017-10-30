using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;

namespace DataService.DTO
{
    public class PostTagsDTO
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public virtual PostDTO Post { get; set; }
        public virtual TagsDTO Tag { get; set; }

        public PostTagsDTO (int PostId, int TagId, Post Post, Tags Tag) 
        {
            this.PostId = PostId;
            this.TagId = TagId;
            this.Post = Post;
            this.Tag = Tag;

        }

    }
}
