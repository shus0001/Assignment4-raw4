using System;
using System.Collections.Generic;
using System.Text;

namespace _0._Models
{
    public class Product
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = null;
        public int CategoryId { get; set; } = 0;
        public Category Category { get; set; } = null;
        public string QuantityPerUnit { get; set; } = null;
        public int UnitPrice { get; set; } = 0;
        public int UnitsInStock { get; set; } = 0;
    }
}