using Microsoft.EntityFrameworkCore;

namespace api_demo_e19.Models
{
    public class AppDBContext(DbContextOptions<AppDBContext> option) : DbContext(option)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}