using _1._Data_Layer_Abstraction;
using _2._Data_Layer;
using _2._Data_Layer.Database_Context;
using System;

namespace _0._Factory
{
    public class Factory
    {
        private NorthwindContext databaseContext = null;
        public ICategoryRepository CategoryRepository
        {
            get
            {
                return new CategoryRepository(DatabaseContext);
            }
        }

        public IOrderRepository OrderRepository
        {
            get
            {
                return new OrderRepository(DatabaseContext);
            }
        }

        public IOrderDetailsRepository OrderDetailsRepository
        {
            get
            {
                return new OrderDetailsRepository(DatabaseContext);
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return new ProductRepository(DatabaseContext);
            }
        }

        private NorthwindContext DatabaseContext
        {
            get
            {
                if (databaseContext == null)
                {
                    databaseContext = new NorthwindContext();
                }
                return databaseContext;
            }
        }
    }
}