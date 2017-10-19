using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace DataServiceProject.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public float UnitPrice { get; set; }
        public float Discount { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public float Quantity { get; set; }
    }
}
