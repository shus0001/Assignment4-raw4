using _0._Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._Data_Layer_Abstraction
{
    public interface IOrderDetailsRepository
    {
        IEnumerable<OrderDetails> GetByOrderId(int id);
        IEnumerable<OrderDetails> GetByProductId(int id);
    }
}