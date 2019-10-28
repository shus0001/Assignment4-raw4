﻿using _0._Models;
using _1._Data_Layer_Abstraction;
using _2._Data_Layer.Database_Context;
using System;
using System.Collections.Generic;
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
            foreach (var o in databaseContext.OrderDetails)
            {
                if(o != null && o.OrderId == id)
                    yield return o;
            }
        }

        public IEnumerable<OrderDetails> GetByProductId(int id)
        {
            foreach (var o in databaseContext.OrderDetails)
            {
                if (o != null && o.ProductId == id)
                    yield return o;
            }
        }
    }
}