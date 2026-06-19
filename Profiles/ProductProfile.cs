using api_demo_e19.DTO;
using api_demo_e19.Models;
using AutoMapper;

namespace api_demo_e19.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponseDTO>();
            CreateMap<ProductRequestDTO, Product>();
        }
    }
}
