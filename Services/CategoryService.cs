using api_demo_e19.DTO;
using api_demo_e19.Models;
using Microsoft.EntityFrameworkCore;

namespace api_demo_e19.Services
{
    public class CategoryService(AppDBContext _db) : ICategoryService
    {
        public async Task<BaseResponse<List<Category>>> GetList()
        {
            var categories = await _db.Categories.ToListAsync();

            var response = new BaseResponse<List<Category>>
            {
                statusCode = 200,
                devErrorMessage = "",
                data = categories
            };

            return response;
        }
    }
}
