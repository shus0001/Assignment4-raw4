using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1._Northwind_API.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
