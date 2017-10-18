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
        public string Name { get; set; }
        public string UnitPrice { get; set; }
        public string QuantityPerUnit { get; set; }
        public string UnitsInStick { get; set; }

    }
}
