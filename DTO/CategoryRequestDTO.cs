using System.ComponentModel.DataAnnotations;

namespace api_demo_e19.DTO
{
    public class CategoryRequestDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
    }
}
