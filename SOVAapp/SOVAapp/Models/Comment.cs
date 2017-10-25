using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{

    public class Comment
    {

        public int Id { get; set; }
        public int PostId { get; set; }
        public String Text { get; set; }
        public int Score { get; set; }
        public DateTime CreationDate { get; set; }
        public string OwneruserId { get; set; }

    }
}

