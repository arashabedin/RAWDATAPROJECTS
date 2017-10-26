using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public int OwnerUserAge { get; set; }
        public String OwnerUserDisplayName { get; set; }
        public DateTime CreationDate { get; set; }
        public string OwnerUserLocation { get; set; }
        public ICollection<Post> Posts;
        public ICollection<Comment> Comments;
    }
}
