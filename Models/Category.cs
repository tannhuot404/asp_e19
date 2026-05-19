using System.ComponentModel.DataAnnotations;

namespace api_demo_e19.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;
    }
}
