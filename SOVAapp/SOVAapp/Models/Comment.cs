using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{

    public class Comment
    {

            public int Commentid { get; set; }
            public int PostId { get; set; }
            public String Commenttext { get; set; }
            public int Commentscore { get; set; }
            public DateTime Commentcreatedate { get; set; }
            public int Owneruserid { get; set; }

    }
}

