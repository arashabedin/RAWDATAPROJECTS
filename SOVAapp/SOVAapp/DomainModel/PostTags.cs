using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;

namespace DataService.DomainModel
{
    public class PostTags
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }
        public int TagId { get; set; }
        public virtual Post Post { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
