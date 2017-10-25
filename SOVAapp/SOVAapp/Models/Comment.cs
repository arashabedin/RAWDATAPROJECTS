using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{

    public class Comment
    {

            public int CommentId { get; set; }
            public int PostId { get; set; }
            public String CommentText { get; set; }
            public int CommentScore { get; set; }
            public DateTime CommentCreateDate { get; set; }
            public int OwnerUserId { get; set; }

    }
}

