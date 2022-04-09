using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }

    [Route("api/products")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Some Name",
                    Price = 50
                }
            };

            return Ok(products);
        }
    }
}
