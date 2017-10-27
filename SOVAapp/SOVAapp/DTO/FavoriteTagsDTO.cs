using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;


namespace DataService.DTO
{
    public class FavoriteTagsDTO
    {
        public int User_CustomeField_Id { get; set; }
        public int TagId { get; set; }
        public virtual UserCustomeField UserCustomeField { get; set; }
        public virtual Tags Tag { get; set; }

        public FavoriteTagsDTO (int User_CustomeField_Id, int TagId, UserCustomeField UserCustomeField, Tags Tag)
        {

            this.User_CustomeField_Id = User_CustomeField_Id;
            this.TagId = TagId;
            this.UserCustomeField = UserCustomeField;
            this.Tag = Tag;
        
        }
    }
}
