using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api_demo_e19.Models
{
    public class AppDBContext(DbContextOptions<AppDBContext> option) : IdentityDbContext<AppUser>(option)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // 1. Create static IDs
            string adminRoleId = "555FE21D-CE38-445E-9202-56F3C8663527";
            string userRoleId = "C7336D75-A517-465E-8DF0-76F3FDBB8C5B";
            string adminUserId = "94489878-07AC-4ACC-BDBF-5AE4C4399B8C";

            // 2. Seed the Admin and User Role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN", // Must be uppercase!
                ConcurrencyStamp = adminRoleId
            }, new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER", // Must be uppercase!
                ConcurrencyStamp = userRoleId
            });

            // 3. Setup the Admin User
            var adminUser = new AppUser
            {
                Id = adminUserId,
                FirstName = "Dara",
                LastName = "Sok",
                UserName = "admin",
                NormalizedUserName = "ADMIN@EXAMPLE.COM", // Must be uppercase!
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",    // Must be uppercase!
                EmailConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEKD1BHMFNGcC1AUVMIjURQL5Xt0GSQzcKAi6fg9kosGjQHcUDt2fX0kFCSuQueIRAw==",
                ConcurrencyStamp = adminUserId,
                // SecurityStamp must be a fixed, hardcoded string so migrations don't constantly change it
                SecurityStamp = "e96f13b6-75fa-44eb-acda-b6a22f28126e"
            };

            // 4. Hash the password manually (admin123)

            // Seed the User
            builder.Entity<AppUser>().HasData(adminUser);

            // 5. Seed the UserRole intersection table
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            });
        }
    }
}