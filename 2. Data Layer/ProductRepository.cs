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
            foreach(Product p in databaseContext.Products)
            {
                if (p.CategoryId == categoryId)
                    yield return p;
            }
        }

        public IEnumerable<Product> GetByContainedSubstringInName(string substring)
        {
            foreach (Product p in databaseContext.Products)
            {
                if (p.Name.Contains(substring))
                    yield return p;
            }
        }

        public Product GetById(int id)
        {
            return databaseContext.Products.Find(id);
        }
    }
}