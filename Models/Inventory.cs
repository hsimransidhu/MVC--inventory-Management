using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQ_2.Models
{
    // Inventory Model
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int ProductID { get; set; }
        public int StockQuantity { get; set; }
    }
}