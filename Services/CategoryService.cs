using api_demo_e19.DTO;
using api_demo_e19.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api_demo_e19.Services
{
    public class CategoryService(AppDBContext _db, IMapper _mapper) : ICategoryService
    {
        public async Task<BaseResponse<CategoryResponseDTO>> Add(CategoryRequestDTO item)
        {
            var newCate = _mapper.Map<Category>(item);
            _db.Categories.Add(newCate);
            await _db.SaveChangesAsync();

            var data = _mapper.Map<CategoryResponseDTO>(newCate);
            var response = new BaseResponse<CategoryResponseDTO>
            {
                statusCode = 200,
                data = data
            };

            return response;
        }

        public Task<BaseResponse<CategoryResponseDTO>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<List<CategoryResponseDTO>>> GetList()
        {
            // Without Auto Mapper
            /*
            var categories = await _db.Categories
                                      .Select(cate => new CategoryResponseDTO
                                      {
                                          Id = cate.Id,
                                          Name = cate.Name
                                      })
                                      .ToListAsync();
            */

            // With Auto Mapper
            var categories = await _db.Categories
                                      .ProjectTo<CategoryResponseDTO>(_mapper.ConfigurationProvider)
                                      .ToListAsync();


            var response = new BaseResponse<List<CategoryResponseDTO>>
            {
                statusCode = 200,
                devErrorMessage = "",
                data = categories
            };

            return response;
        }

        public Task<BaseResponse<CategoryResponseDTO>> Update(CategoryRequestDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
