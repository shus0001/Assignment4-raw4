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
    public class ProductRepository : IProductRepository
    {
        private NorthwindContext databaseContext;

        public ProductRepository(NorthwindContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IEnumerable<Product> GetByCategoryId(int categoryId)
        {
            return databaseContext.Products.Where(p => p.CategoryId == categoryId);
        }

        public IEnumerable<Product> GetByContainedSubstringInName(string substring)
        {
            return databaseContext.Products.Where(p => p.Name.Contains(substring));
        }

        public Product GetById(int id)
        {
            return databaseContext.Products.Include("Category").Where(p => p.Id == id).First();
        }
    }
}