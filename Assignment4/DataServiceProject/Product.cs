using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataServiceProject
{
    class Product
    {
        [Column("ProductId")]
        public int Id { get; set; }
        [Column("ProductName")]
        public String Name { get; set; }
        [Column("SupplierId")]
        public int SupplierId { get; set; }

        [Column("CategoryId")]
        public int CategoryId { get; set; }
        [Column("QuantityUnit ")]
        public string QuantityPerUnit { get; set; }
        [Column("UnitPrice")]
        public double UnitPrice { get; set; }
        [Column("UnitsInStock")]
        public int UnitsInStock { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }


   
    }
}
