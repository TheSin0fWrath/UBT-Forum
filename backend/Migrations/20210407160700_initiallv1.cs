using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class initiallv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatBox_Users_UserId",
                table: "ChatBox");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ChatBox",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBox_Users_UserId",
                table: "ChatBox",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatBox_Users_UserId",
                table: "ChatBox");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ChatBox",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBox_Users_UserId",
                table: "ChatBox",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
