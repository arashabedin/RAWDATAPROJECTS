using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataServiceProject
{
    class Product
    {
        [Column("ProductId")]
        public int Id { get; set; }
        [Column("ProductName")]
        public String Name { get; set; }
        [Column("ProductUnitPrice")]
        public double UnitPrice { get; set; }
        [Column("ProductQuantityPerUnit ")
        public string QuantityPerUnit { get; set; }
        [Column("ProductUnitsInStock")]
        public int UnitsInStock { get; set; }

    }
}
