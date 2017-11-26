using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DTO
{
   public class TermAsResultDTO
    {

        public string Word { get; set; }
        public double TfIdf { get; set; }
        public TermAsResultDTO( string Word , double TfIdf)
        {
            
            this.Word = Word;
            this.TfIdf = TfIdf;
        }

    }
}
