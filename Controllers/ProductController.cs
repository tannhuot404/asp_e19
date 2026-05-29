using api_demo_e19.DTO;
using api_demo_e19.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api_demo_e19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            var response = new BaseResponse<Product>();
            if (CategoryController.categories.Any(cate => cate.Id == product.CategoryId)) {
                products.Add(product);
                response.devErrorMessage = "";
                response.statusCode = 200;
                response.data = product;
                return Ok(response);
            }

            response.devErrorMessage = "Category not found...";
            response.statusCode = 404;
            return NotFound(response);
        }
    }
}
