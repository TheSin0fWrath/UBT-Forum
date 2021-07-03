using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v65 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Qytetet_qytetiId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "qytetiId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Qytetet_qytetiId",
                table: "Users",
                column: "qytetiId",
                principalTable: "Qytetet",
                principalColumn: "QytetiId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Qytetet_qytetiId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "qytetiId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Qytetet_qytetiId",
                table: "Users",
                column: "qytetiId",
                principalTable: "Qytetet",
                principalColumn: "QytetiId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
