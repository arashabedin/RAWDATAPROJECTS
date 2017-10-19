using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataServiceProject.Models
{
    public class OrderDetails
    {
 
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Order Order { get; set; }
        public Double UnitPrice { get; set; }
        public Double Discount { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
