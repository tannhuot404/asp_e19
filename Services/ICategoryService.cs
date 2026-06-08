using api_demo_e19.DTO;
using api_demo_e19.Models;
using Microsoft.AspNetCore.Mvc;

namespace api_demo_e19.Services
{
    public interface ICategoryService
    {
        Task<BaseResponse<List<Category>>> GetList();
    }
}
