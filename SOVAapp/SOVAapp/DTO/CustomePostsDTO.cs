using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;

namespace DataService.DTO
{
    public class CustomePostsDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int PostTypeId { get; set; }
        public CustomePostsDTO(int PostId, string Title, string Body, int PostTypeId)
        {
            this.PostId = PostId;
            this.Title = Title;
            this.Body = Body;
            this.PostTypeId = PostTypeId;

        }
    }
}
