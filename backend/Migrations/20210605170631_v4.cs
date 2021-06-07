using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Conntact",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Conntact",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
