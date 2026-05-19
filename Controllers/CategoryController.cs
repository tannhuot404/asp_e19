using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace api_demo_e19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        
        public static List<string> categories { get; } = new List<string>
        { "Cate 001", "Cate 002"};

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { data = categories});
        }

        [HttpGet("{id}")]
        public IActionResult GetById(
            [FromRoute] string? id,
            [FromQuery] string? msg
            )
        {
            if (id is not null && categories.Contains(id))
            {
                return Ok(new { message = "Category Found!", msg = msg });
            }
            return BadRequest(new { error = "Category not exist!" });
        }

        [HttpPost]
        public IActionResult Post([FromBody] JsonObject data)
        {
            string? name = data["name"]?.ToString();

            if (name == null || name == "")
            {
                return BadRequest(new { message = "Key name is required and must not empty." });
            }

            categories.Add(name);
            return Ok(new {message = "Success"});
        }
    }
}
