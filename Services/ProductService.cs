using api_demo_e19.DTO;
using api_demo_e19.Models;
using api_demo_e19.Utils;
using api_demo_e19.Utils.QueryParams;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace api_demo_e19.Services
{
    public class ProductService(AppDBContext _db, IMapper _mapper) : IProductService
    {
        public async Task<BaseResponse<List<ProductResponseDTO>>> GetList(ProductQueryParams queryParams)
        {
            // Create Query
            var query = _db.Products.AsQueryable();

            // Check if search product by name
            if (!string.IsNullOrEmpty(queryParams.SearchText))
            {
                query = query.Where(p => p.Name.Contains(queryParams.SearchText));
            }

            // Search product by Category
            if (queryParams.CategoryId > 0)
            {
                // If category id not exist return BadRequest
                if (!await _db.Categories.AnyAsync(c => c.Id == queryParams.CategoryId))
                {
                    //return errror
                }
                query = query.Where(p => p.CategoryId == queryParams.CategoryId);
            }

            // Sorting: name, name_desc, price, price_desc
            switch (queryParams.Sort.ToLower())
            {
                case "name":
                    query = query.OrderBy(p => p.Name);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(p => p.Name);
                    break;
                case "price":
                    query = query.OrderBy(p => p.Price);
                    break;
                case "price_desc":
                    query = query.OrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }

            // Count Total Record
            var totalRecord = await query.CountAsync();

            // PAGINATION 
            // Skip(x): bypass the first x items. Take(y): grab the next y items. 
            var itemsToSkip = (queryParams.Page - 1) * GlobalConstants.PageSize;

            var data = await query
                .Skip(itemsToSkip)
                .Take(GlobalConstants.PageSize)
                .ProjectTo<ProductResponseDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var metaData = new ListMetaData
            {
                TotalCount = totalRecord,
                PageNumber = queryParams.Page,
                
            };

            var response = new BaseResponse<List<ProductResponseDTO>>
            {
                statusCode = 200,
                data = data,
                ListMetaData = metaData
            };

            return response;
        }
    }
}
