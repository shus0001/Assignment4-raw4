using _0._Models;
using _1._Data_Layer_Abstraction;
using _2._Data_Layer.Database_Context;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var nextId = databaseContext.Categories.Max(x => x.Id) + 1;

            var cat = new Category
            {
                Id = nextId,
                Name = name,
                Description = description
            };

            databaseContext.Categories.Add(cat);

            databaseContext.SaveChanges();

            return cat;
        }

        public bool Delete(int id)
        {
            if (databaseContext.Categories.Find(id) != null)
            {
                databaseContext.Categories.Remove(databaseContext.Categories.Find(id));
                databaseContext.SaveChanges();

                return true;
            }

            databaseContext.SaveChanges();

            return false;
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