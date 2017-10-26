using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public class PostTags
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public virtual Post Post { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
