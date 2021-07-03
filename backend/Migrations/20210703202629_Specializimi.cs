using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class Specializimi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecializimiId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specializime",
                columns: table => new
                {
                    SpecializimiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializimiText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializime", x => x.SpecializimiId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpecializimiId",
                table: "Users",
                column: "SpecializimiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Specializime_SpecializimiId",
                table: "Users",
                column: "SpecializimiId",
                principalTable: "Specializime",
                principalColumn: "SpecializimiId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Specializime_SpecializimiId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Specializime");

            migrationBuilder.DropIndex(
                name: "IX_Users_SpecializimiId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SpecializimiId",
                table: "Users");
        }
    }
}
