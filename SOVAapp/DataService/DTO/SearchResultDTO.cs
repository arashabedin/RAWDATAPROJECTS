using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DTO
{
    public class SearchResultDTO
    {

        public int Id;
        public string Title;
        public string Body;
        public double Rank;
        public int? totalResults { get; set; }
        public SearchResultDTO(int Id, string Title, string Body, double Rank )
        {
            this.Id = Id;
            this.Title = Title;
            this.Body = Body;
            this.Rank = Rank;
        }
    }
}
