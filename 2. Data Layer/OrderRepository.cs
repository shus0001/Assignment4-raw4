﻿using _0._Models;
using _1._Data_Layer_Abstraction;
using _2._Data_Layer.Database_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._Data_Layer
{
    public class OrderRepository : IOrderRepository
    {
        private NorthwindContext databaseContext;

        public OrderRepository(NorthwindContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<Order> GetAll()
        {
            return databaseContext.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return databaseContext.Orders.Find(id);
        }

        public IEnumerable<Order> GetByShippingName(string shippingName)
        {
            return databaseContext.Orders.Where(o => o.ShipName == shippingName);
        }
    }
}