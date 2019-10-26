using _0._Models;
using _1._Data_Layer_Abstraction;
using _2._Data_Layer.Database_Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2._Data_Layer
{
    public class CategoryRepository : ICategoryRepository
    {
        private NorthwindContext databaseContext;
        
        public CategoryRepository(NorthwindContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public Category Create(string name, string description)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, string name, string description)
        {
            throw new NotImplementedException();
        }
    }
}