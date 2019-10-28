using System;
using System.Collections.Generic;
using System.Text;

namespace _0._Models
{
    public class Order
    {
        public int Id { get; set; } = 0;
        public DateTime Date { get; set; }
        public DateTime Required { get; set; }
        public DateTime Shipped { get; set; }
        public int Freight { get; set; } = 0;
        public OrderDetails OrderDetails { get; set; } = null;
        public string ShipName { get; set; } = null;
        public string ShipCity { get; set; } = null;
    }
}