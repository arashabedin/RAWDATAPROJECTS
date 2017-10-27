using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DomainModel
{
    public class FavoriteTags
    {
        public int User_CustomeField_Id { get; set; }
        public int TagId { get; set; }
        public virtual UserCustomeField UserCustomeField { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
