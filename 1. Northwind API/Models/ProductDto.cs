using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1._Northwind_API.Models
{
    public class ProductDto
    {
        public string Link { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}
