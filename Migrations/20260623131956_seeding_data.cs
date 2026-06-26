using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_demo_e19.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "555FE21D-CE38-445E-9202-56F3C8663527", "555FE21D-CE38-445E-9202-56F3C8663527", "Admin", "ADMIN" },
                    { "C7336D75-A517-465E-8DF0-76F3FDBB8C5B", "C7336D75-A517-465E-8DF0-76F3FDBB8C5B", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "94489878-07AC-4ACC-BDBF-5AE4C4399B8C", 0, "94489878-07AC-4ACC-BDBF-5AE4C4399B8C", "admin@example.com", true, "Dara", "Sok", false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEKD1BHMFNGcC1AUVMIjURQL5Xt0GSQzcKAi6fg9kosGjQHcUDt2fX0kFCSuQueIRAw==", null, false, "e96f13b6-75fa-44eb-acda-b6a22f28126e", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "555FE21D-CE38-445E-9202-56F3C8663527", "94489878-07AC-4ACC-BDBF-5AE4C4399B8C" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "C7336D75-A517-465E-8DF0-76F3FDBB8C5B");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "555FE21D-CE38-445E-9202-56F3C8663527", "94489878-07AC-4ACC-BDBF-5AE4C4399B8C" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "555FE21D-CE38-445E-9202-56F3C8663527");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "94489878-07AC-4ACC-BDBF-5AE4C4399B8C");
        }
    }
}
