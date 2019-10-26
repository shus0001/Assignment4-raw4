﻿using _0._Models;
using _1._Data_Layer_Abstraction.Generic_Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Data_Layer_Abstraction
{
    public interface ICategoryRepository : IGetSingleRepository<Category>, IGetAllRepository<Category>
    {
        Category Create(string name, string description);
        bool Update(int id, string name, string description);
        bool Delete(int id);
    }
}