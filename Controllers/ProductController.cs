using api_demo_e19.DTO;
using api_demo_e19.Models;
using api_demo_e19.Services;
using api_demo_e19.Utils.QueryParams;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_demo_e19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService _productService) : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ProductQueryParams queryParams) {

            var response = await _productService.GetList(queryParams);

            if (!response.IsSuccess) return BadRequest(response);

            return Ok(response);
        }

        // For add testing data
        /*
        [HttpGet("test")] // api/product/test
        public async Task AddTestData()
        {
            var products = new List<Product>();

            for(int i = 1; i < 106; i++)
            {
                products.Add(new Product
                {
                    Name = $"Product {i}",
                    Price = 100 * Math.Round(Random.Shared.NextDouble(), 4),
                    SuplierCost = 100 * Math.Round(Random.Shared.NextDouble(), 4),
                    CategoryId = Random.Shared.Next(3, 5)
                });
            }
            _db.AddRange(products);
            await _db.SaveChangesAsync();

        }
        */
    }
}
