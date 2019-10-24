using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Order
    {
        [Column("orderid")]
        public int Id { get; set; }

        [Column("orderdate")]
        public DateTime Date { get; set; }

        [Column("requireddate")]
        public DateTime Required { get; set; }

        [Column("shippeddate")]
        public DateTime Shipped { get; set; }
        public int Freight { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public string ShipName { get; set; }
        public string ShipCity { get; set; }
    }
}