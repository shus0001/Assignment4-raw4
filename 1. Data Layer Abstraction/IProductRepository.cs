﻿using _0._Models;
using _1._Data_Layer_Abstraction.Generic_Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Data_Layer_Abstraction
{
    public interface IProductRepository : IGetSingleRepository<Product>
    {
        IEnumerable<Product> GetByContainedSubstringInName(string substring);
        IEnumerable<Product> GetByCategoryId(int categoryId);
    }
}