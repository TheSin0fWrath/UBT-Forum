using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class initilv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gjenerat",
                table: "UsersInfos",
                newName: "Gjenerata");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gjenerata",
                table: "UsersInfos",
                newName: "Gjenerat");
        }
    }
}
