using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class vtestprofa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ABC",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ABC",
                table: "Roles");
        }
    }
}
