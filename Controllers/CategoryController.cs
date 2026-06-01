using api_demo_e19.DTO;
using api_demo_e19.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Text.Json.Nodes;

namespace api_demo_e19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        
        public static List<Category> categories { get; } = new List<Category>
        { new Category()
            {
                Id = 1,
                Name = "Test"
            },
           new Category()
            {
                Id = 2,
                Name = "Test"
            }
        };

        /// <summary>
        /// Get Category List
        /// </summary>
        /// 
        [HttpGet]
        //[ProducesResponseType(typeof(BaseResponse<List<Category>>), 200)]
        [ProducesResponseType<BaseResponse<List<Category>>>(200)]
        [ProducesResponseType<BaseResponse<List<Category>>>(400)]
        public IActionResult Get()
        {
            var response = new BaseResponse<List<Category>>
            {
                statusCode = 200,
                devErrorMessage = "",
                data = categories
            };
            return Ok(response);
        }

        /// <summary>
        /// Get Category by ID
        /// </summary>
        /// <param name="id" example="42">Tesing</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(
            [FromRoute] int id
            )
        {
            if (categories.Any(item => item.Id == id))
            {
                return Ok(new { message = "Category Found!" });
            }
            return BadRequest(new { error = "Category not exist!" });
        }

        /// <summary>
        /// Create new Category
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Category data)
        {
            categories.Add(data);
            return Ok(new {message = "Success"});
        }
    }
}
