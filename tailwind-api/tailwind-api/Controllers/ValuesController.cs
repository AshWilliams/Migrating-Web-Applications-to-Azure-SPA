using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using tailwind_api.Models;

namespace tailwind_api.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("coolapi/tailwind")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public List<Product> Get()
        {
            var productList = new List<Product>();
            var product1 = new Product
            {
                ID = 205,
                Name = "Extension Cord",
                SKU = "TT2051",
                Price = "15",
                Supplier = "Northwind",
                Inventory = 12
            };
            var product2 = new Product
            {
                ID = 206,
                Name = "Led Lamp",
                SKU = "TT2052",
                Price = "24",
                Supplier = "Northwind",
                Inventory = 17
            };
            var product3 = new Product
            {
                ID = 207,
                Name = "Led Lamp",
                SKU = "TT2053",
                Price = "150",
                Supplier = "Tailwind Wholesale",
                Inventory = 34
            };
            var product4 = new Product
            {
                ID = 208,
                Name = "Timer Outlet",
                SKU = "TT2054",
                Price = "54",
                Supplier = "Northwind",
                Inventory = 31
            };
            var product5 = new Product
            {
                ID = 209,
                Name = "Paint Roller",
                SKU = "TT2055",
                Price = "200",
                Supplier = "Northwind",
                Inventory = 100
            };
            var product6 = new Product
            {
                ID = 210,
                Name = "Sponge",
                SKU = "TT2056",
                Price = "15",
                Supplier = "Northwind",
                Inventory = 120
            };
            var product7 = new Product
            {
                ID = 211,
                Name = "Tile Backsplash",
                SKU = "TT2057",
                Price = "150",
                Supplier = "Tailwind Wholesale",
                Inventory = 10
            };
            var product8 = new Product
            {
                ID = 212,
                Name = "Extension Cord",
                SKU = "TT2058",
                Price = "28",
                Supplier = "Tailwind Wholesale",
                Inventory = 80
            };
            var product9 = new Product
            {
                ID = 213,
                Name = "Tile Backsplash",
                SKU = "TT2059",
                Price = "35",
                Supplier = "Tailwind Wholesale",
                Inventory = 22
            };
            var product10 = new Product
            {
                ID = 214,
                Name = "Tile Backsplash",
                SKU = "TT2060",
                Price = "152",
                Supplier = "Northwind",
                Inventory = 126
            };
            var product11 = new Product
            {
                ID = 215,
                Name = "Tile Backsplash",
                SKU = "TT2061",
                Price = "85",
                Supplier = "Tailwind Wholesale",
                Inventory = 42
            };
            var product12 = new Product
            {
                ID = 216,
                Name = "Tile Backsplash",
                SKU = "TT2062",
                Price = "40",
                Supplier = "Northwind",
                Inventory = 30
            };

            productList.Add(product1);
            productList.Add(product2);
            productList.Add(product3);
            productList.Add(product4);
            productList.Add(product5);
            productList.Add(product6);
            productList.Add(product7);
            productList.Add(product8);
            productList.Add(product9);
            productList.Add(product10);
            productList.Add(product11);
            productList.Add(product12);
            return productList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
