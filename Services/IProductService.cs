using api_demo_e19.DTO;
using api_demo_e19.Utils.QueryParams;

namespace api_demo_e19.Services
{
    public interface IProductService
    {
        Task<BaseResponse<List<ProductResponseDTO>>> GetList(ProductQueryParams queryParams);
        Task<BaseResponse<ProductResponseDTO>> AddNew(ProductRequestDTO item);
    }
}
