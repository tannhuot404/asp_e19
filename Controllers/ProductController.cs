using api_demo_e19.DTO;
using api_demo_e19.Models;
using api_demo_e19.Utils.QueryParams;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_demo_e19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IMapper mapper) : ControllerBase
    {
        public static List<Product> Products = new List<Product>();

        [HttpGet]
        public IActionResult Get([FromQuery] ProductQueryParams queryParams) {
            Console.WriteLine($"Page: {queryParams.Page} search: {queryParams.SearchText}");
            var response = new BaseResponse<List<Product>>();
            response.data = Products;
            return Ok(response);
        }
    }
}
