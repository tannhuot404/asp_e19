using api_demo_e19.Models;

namespace api_demo_e19.DTO
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public CategoryResponseDTO Category { get; set; }
    }
}
