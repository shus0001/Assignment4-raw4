using _0._Models;
using _2._Data_Layer_Abstraction;
using _3._Data_Layer.Database_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3._Data_Layer
{
    public class CategoryRepository : ICategoryRepository
    {
        private NorthwindContext databaseContext;

        public CategoryRepository(NorthwindContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public IList<Category> GetCategories(PagingAttributes pagingAttributes)
        {
            return databaseContext.Categories
                .Skip(pagingAttributes.Page * pagingAttributes.PageSize)
                .Take(pagingAttributes.PageSize)
                .ToList();
        }

        public int NumberOfCategories()
        {
            return databaseContext.Categories.Count();
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
            return false;
        }

        public IEnumerable<Category> GetAll()
        {
            return databaseContext.Categories;
        }

        public Category GetById(int id)
        {
            return databaseContext.Categories.Find(id);
        }

        public bool Update(int id, string name, string description)
        {
            var cat = databaseContext.Categories.Find(id);
            if (cat != null)
            {
                cat.Description = description;
                cat.Name = name;

                databaseContext.SaveChanges();

                return true;
            }
            return false;
        }
    }
}