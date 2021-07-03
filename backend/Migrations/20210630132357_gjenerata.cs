using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class gjenerata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gjenerata",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "gjenerataId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Gjeneratat",
                columns: table => new
                {
                    GjenerataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GjenerataText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gjeneratat", x => x.GjenerataId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_gjenerataId",
                table: "Users",
                column: "gjenerataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Gjeneratat_gjenerataId",
                table: "Users",
                column: "gjenerataId",
                principalTable: "Gjeneratat",
                principalColumn: "GjenerataId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Gjeneratat_gjenerataId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Gjeneratat");

            migrationBuilder.DropIndex(
                name: "IX_Users_gjenerataId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "gjenerataId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Gjenerata",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
