using _0._Models;
using _1._Data_Layer_Abstraction;
using _2._Data_Layer.Database_Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._Data_Layer
{
    public class OrderDetailsRepository : IOrderDetailsRepository
    {
        private NorthwindContext databaseContext;

        public OrderDetailsRepository(NorthwindContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<OrderDetails> GetByOrderId(int id)
        {
            return databaseContext.OrderDetails.Include("Product").Where(o => o.OrderId == id);
        }

        public IEnumerable<OrderDetails> GetByProductId(int id)
        {
            return databaseContext.OrderDetails.Include("Order").Where(o => o.ProductId == id);
        }
    }
}