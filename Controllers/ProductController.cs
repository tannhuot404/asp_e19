using api_demo_e19.DTO;
using api_demo_e19.Models;
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

        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public IActionResult Get() {
            var response = new BaseResponse<List<Product>>();
            response.data = Products;
            return Ok(response);
        }
    }
}
