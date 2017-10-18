using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataServiceProject
{
    class OrderDetails
    {
        [Column("OrderId")]
        public int UnitPrice { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
    }
}
