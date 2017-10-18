using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataServiceProject
{
    class OrderDetails
    {
        [Column("OrderId")]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Double UnitPrice { get; set; }
        public int  Quantity { get; set; }
        public Double Discount { get; set; }
      //  public Order Order { get; set; }
    }
}
