using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQ_2.Models
{
    // Product Model
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    
}   