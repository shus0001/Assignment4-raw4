using _0._Models;
using _2._Data_Layer_Abstraction.Generic_Repository_Interfaces;
using System.Collections.Generic;

namespace _2._Data_Layer_Abstraction
{
    public interface ICategoryRepository : IGetSingleRepository<Category>, IGetAllRepository<Category>
    {
        IList<Category> GetCategories(PagingAttributes pagingAttributes);
        int NumberOfCategories();
        Category Create(string name, string description);
        bool Update(int id, string name, string description);
        bool Delete(int id);
    }
}