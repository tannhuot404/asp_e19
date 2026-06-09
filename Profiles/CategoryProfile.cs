using api_demo_e19.DTO;
using api_demo_e19.Models;
using AutoMapper;

namespace api_demo_e19.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() {
            CreateMap<Category, CategoryResponseDTO>();

            CreateMap<CategoryRequestDTO, Category>();
        }
    }
}
