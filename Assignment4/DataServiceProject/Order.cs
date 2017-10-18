using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataServiceProject
{
    class Order
    {
       [Column("OrderId")]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
        public DateTime Shipped { get; set; }
        public Double  Frieght { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }

}
