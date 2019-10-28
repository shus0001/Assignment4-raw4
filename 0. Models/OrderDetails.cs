using System;
using System.Collections.Generic;
using System.Text;

namespace _0._Models
{
    public class OrderDetails
    {
        public int Quantity { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public int OrderId { get; set; } = 0;
        public Order Order { get; set; } = null;
        public int ProductId { get; set; } = 0;
        public Product Product { get; set; } = null;
        public int UnitPrice { get; set; } = 0;
    }
}
