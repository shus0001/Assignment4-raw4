using System;
using System.Collections.Generic;
using System.Text;

namespace _1._Data_Layer_Abstraction.Generic_Repository_Interfaces
{
    public interface IGetSingleRepository<T>
    {
        T GetById(int id);
    }
}