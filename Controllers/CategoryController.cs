using api_demo_e19.DTO;
using api_demo_e19.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Text.Json.Nodes;

namespace api_demo_e19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(AppDBContext _db) : ControllerBase
    {
        /// <summary>
        /// Get Category List
        /// </summary>
        /// 
        [HttpGet]
        //[ProducesResponseType(typeof(BaseResponse<List<Category>>), 200)]
        [ProducesResponseType<BaseResponse<List<Category>>>(200)]
        [ProducesResponseType<BaseResponse<List<Category>>>(400)]
        public IActionResult GetCategoryList()
        {
            var categories = _db.Categories.ToList();

            var response = new BaseResponse<List<Category>>
            {
                statusCode = 200,
                devErrorMessage = "",
                data = categories
            };
            return Ok(response);
        }

        /// <summary>
        /// Create new Category
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddNewCategory([FromBody] Category data)
        {
            _db.Categories.Add(data);
            _db.SaveChanges();

            var response = new BaseResponse<Category>
            {
                statusCode = 200,
                devErrorMessage = "",
                data = data
            };

            return Ok(response);
        }
    }
}
