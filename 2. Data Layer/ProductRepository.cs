using _0._Models;
using _1._Data_Layer_Abstraction;
using _2._Data_Layer.Database_Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._Data_Layer
{
    public class ProductRepository : IProductRepository
    {
        private NorthwindContext databaseContext;

        public ProductRepository(NorthwindContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetByContainedSubstringInName(string substring)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}