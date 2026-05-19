using api_demo_e19.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { data = categories});
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            [FromRoute] int id,
            [FromQuery] string? msg
            )
        {
            if (categories.Any(item => item.Id == id))
            {
                return Ok(new { message = "Category Found!", msg = msg });
            }
            return BadRequest(new { error = "Category not exist!" });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Category data)
        {
            categories.Add(data);
            return Ok(new {message = "Success"});
        }
    }
}
