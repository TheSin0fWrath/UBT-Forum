using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class _8th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserInfoFk",
                table: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserInfoFk",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
