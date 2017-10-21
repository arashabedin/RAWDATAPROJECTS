using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;



namespace DataServiceProject.Models
{
    public class Category
    {
        [Column("CategoryId")]
        public int Id { get; set; }
        [Column("CategoryName")]

        public string Name { get; set; }
        [Column("Description")]

        public string Description { get; set; }

    }

}
