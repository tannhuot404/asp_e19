using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace api_demo_e19.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        public List<Product>? Products { get; set; }

        public string AppUserId { get; set; }
        public AppUser? User { get; set; }

    }
}
