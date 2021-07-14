using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class iniv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Drejtime_DrejtimiId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Nivelis_NiveliId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NiveliId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DrejtimiId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Drejtime_DrejtimiId",
                table: "Users",
                column: "DrejtimiId",
                principalTable: "Drejtime",
                principalColumn: "DrejtimiId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Users_Drejtime_DrejtimiId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Nivelis_NiveliId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NiveliId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DrejtimiId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Drejtime_DrejtimiId",
                table: "Users",
                column: "DrejtimiId",
                principalTable: "Drejtime",
                principalColumn: "DrejtimiId",
                onDelete: ReferentialAction.Cascade);

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
