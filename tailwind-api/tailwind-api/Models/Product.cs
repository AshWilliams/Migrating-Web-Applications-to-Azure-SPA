using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tailwind_api.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string Price { get; set; }
        public string Supplier { get; set; }
        public int Inventory { get; set; }
    }
}
