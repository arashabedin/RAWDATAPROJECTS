using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.DomainModel
{
    public class TermScore
    {
        public int Id { get; set; }

        public string Word { get; set; }
        public int Tf { get; set; }
        public int Idf { get; set; }
        public int TfIdf { get; set; }

    }
}
