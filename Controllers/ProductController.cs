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

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductRequestDTO productDTO)
        {
            var response = new BaseResponse<Product>();
            if (CategoryController.categories.Any(cate => cate.Id == productDTO.CategoryId)) {
                var newId = (Products.MaxBy(item => item.Id)?.Id ?? 0) + 1;

                var newProduct = _mapper.Map<Product>(productDTO);
                newProduct.Id = newId;

                Products.Add(newProduct);
                response.devErrorMessage = "";
                response.statusCode = 200;
                response.data = newProduct;
                return Ok(response);
            }

            response.devErrorMessage = "Category not found...";
            response.statusCode = 404;
            return NotFound(response);
        }
    }
}
