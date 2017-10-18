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
        public string Date { get; set; }
        public string Require { get; set; }
        public string Shipped { get; set; }
        public double Frieght { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
    }

}
