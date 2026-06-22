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
        public async Task<BaseResponse<ProductResponseDTO>> AddNew(ProductRequestDTO item)
        {
            if (string.IsNullOrEmpty(item.Name) || item.Name.Length < 3 || item.Name.Length > 50)
            {
                return BaseResponse<ProductResponseDTO>.Failure("Not valid name.");
            }

            if (item.Price < 0 || item.SuplierCost < 0)
            {
                return BaseResponse<ProductResponseDTO>.Failure("Price/SuplierCost must be positive.");
            }

            if (!await _db.Categories.AnyAsync(c => c.Id == item.CategoryId))
            {
                return BaseResponse<ProductResponseDTO>.Failure("Category doest not exist.");
            }

            Product newProduct = _mapper.Map<Product>(item);
            Console.WriteLine($"From Postman: \n{item}");
            Console.WriteLine($"From mapper: \n{newProduct}");

            //_db.Products.Add(newProduct);
            //await _db.SaveChangesAsync();

            var data = _mapper.Map<ProductResponseDTO>(newProduct);
            return BaseResponse<ProductResponseDTO>.Sucess(data);
        }

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
                    return BaseResponse<List<ProductResponseDTO>>.Failure("Bad Rquest");
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

            return BaseResponse<List<ProductResponseDTO>>.Sucess(data, metaData);
        }
    }
}
