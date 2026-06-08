using api_demo_e19.DTO;
using api_demo_e19.Models;
using api_demo_e19.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Text.Json.Nodes;

namespace api_demo_e19.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(AppDBContext _db, ICategoryService _categoryService) : ControllerBase
    {
        /// <summary>
        /// Get Category List
        /// </summary>
        /// 
        [HttpGet]
        //[ProducesResponseType(typeof(BaseResponse<List<Category>>), 200)]
        [ProducesResponseType<BaseResponse<List<Category>>>(200)]
        [ProducesResponseType<BaseResponse<List<Category>>>(400)]
        public async Task<IActionResult> GetCategoryList()
        {
            return Ok(await _categoryService.GetList());
        }
        
        /// <summary>
        /// Create new Category
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddNewCategory([FromBody] Category data)
        {
            await _db.Categories.AddAsync(data);
            await _db.SaveChangesAsync();

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
