﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Product
    {
        [Column("productid")]
        public int Id { get; set; }

        [Column("productname")]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
    }
}