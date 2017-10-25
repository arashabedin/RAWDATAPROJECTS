using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int PostTypeId { get; set; }
        public int ParentId { get; set; }
        public int AcceptedAnswerId { get; set; }
        public int LinkPostId { get; set; }
        public int OwneruserId { get; set; }
        public String Body { get; set; }
        public String Title { get; set; }
        public int Score { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ClosedDate { get; set; }



    }
}
