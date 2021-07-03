using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descritpion",
                table: "Roles",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Roles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Roles");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Roles",
                newName: "Descritpion");
        }
    }
}
