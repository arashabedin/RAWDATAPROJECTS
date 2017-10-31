using System;
using System.Collections.Generic;
using System.Text;
using DataService.DomainModel;

namespace DataService.DTO
{
    public class UserInfoDTO
    {
        public int Id { get; set; }
        public int? OwnerUserAge { get; set; }
        public String OwnerUserDisplayName { get; set; }
        public DateTime CreationDate { get; set; }
        public string OwnerUserLocation { get; set; }

       

        public UserInfoDTO(int Id, int? OwnerUserAge, String OwnerUserDisplayName, DateTime CreationDate, string OwnerUserLocation)
        {

            this.Id = Id;
            this.OwnerUserAge = OwnerUserAge;
            this.OwnerUserDisplayName = OwnerUserDisplayName;
            this.CreationDate = CreationDate;
            this.OwnerUserLocation = OwnerUserLocation;
         
        }
    }
}
