using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQ_2.Models
{
    // ViewModel class for logic to combine data of products and inventory


    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

}