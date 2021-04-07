using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ChatBox",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatBox_UserId",
                table: "ChatBox",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChatBox_Users_UserId",
                table: "ChatBox",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatBox_Users_UserId",
                table: "ChatBox");

            migrationBuilder.DropIndex(
                name: "IX_ChatBox_UserId",
                table: "ChatBox");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ChatBox");
        }
    }
}
