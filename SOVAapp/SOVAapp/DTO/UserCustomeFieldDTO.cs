﻿using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;

namespace DataService.DTO
{
    public class UserCustomeFieldDTO
    {
        public int Id { get; set; }
        public int Postlimit { get; set; }
        public string CreationDate { get; set; }
        public ICollection<FavoriteTagsDTO> FavoriteTags;

        public UserCustomeFieldDTO (int Id, int Postlimit, string CreationDate, ICollection<FavoriteTagsDTO> FavoriteTags)
        {
            this.Id = Id;
            this.Postlimit = Postlimit;
            this.CreationDate = CreationDate;
            this.FavoriteTags = FavoriteTags;
        }

    }
}
