using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    // https:host:port/api/products
    [Route("api/products")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            // throw new Exception("my test exception");
            var products = new List<Product>
            {
                new Product { Name = "Computers", Price = 150 },
                new Product { Name = "Mobile phones", Price = 300 },
                new Product { Name = "Cameras", Price = 250 },
                new Product { Name = "Household furniture", Price = 10 },
                new Product { Name = "Clothing", Price = 35 }
            };

            return Ok(products);
        }

        [HttpPost]
        public IActionResult PostTestData([FromQuery] string data)
        {
            // Save date
            return Ok($"{data} + saved");
        }
    }
}
