using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_demo_e19.Migrations
{
    /// <inheritdoc />
    public partial class remove_default_value_cate_userID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldDefaultValue: "94489878-07AC-4ACC-BDBF-5AE4C4399B8C");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "94489878-07AC-4ACC-BDBF-5AE4C4399B8C",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
