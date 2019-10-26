﻿using _0._Models;
using _1._Data_Layer_Abstraction.Generic_Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Data_Layer_Abstraction
{
    public interface IOrderRepository : IGetSingleRepository<Order>, IGetAllRepository<Order>
    {
        IEnumerable<Order> GetByShippingName(string shippingName);
    }
}