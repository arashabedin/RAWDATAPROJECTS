﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public String Tag { get; set; }
        public ICollection<PostTags> PostTags;
        public ICollection<FavoriteTags> FavoriteTags;
    }
}
