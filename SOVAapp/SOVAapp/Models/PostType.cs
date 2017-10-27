using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public class PostType
    {

        public int Id { get; set; }
        public String Type { get; set; }
        public ICollection<Post> Posts;
    }
}
