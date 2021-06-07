using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Nivelis_NiveliId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "NiveliId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Nivelis_NiveliId",
                table: "Users",
                column: "NiveliId",
                principalTable: "Nivelis",
                principalColumn: "Niveli_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Nivelis_NiveliId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "NiveliId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Nivelis_NiveliId",
                table: "Users",
                column: "NiveliId",
                principalTable: "Nivelis",
                principalColumn: "Niveli_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
