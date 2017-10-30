using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;

namespace DataService.DTO
{
    public class TagsDTO
    {
        public int Id { get; set; }
        public String Tag { get; set; }
        public ICollection<PostTagsDTO> PostTags;
        public ICollection<FavoriteTagsDTO> FavoriteTags;

        public TagsDTO(int Id, String Tag, ICollection<PostTagsDTO> PostTags, ICollection<FavoriteTagsDTO> FavoriteTags)
        {
            this.Id = Id;
            this.Tag = Tag;
            this.PostTags = PostTags;
            this.FavoriteTags = FavoriteTags;

        }
    }
}
