using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class _5th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersInfos_UserId",
                table: "UsersInfos");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfos_UserId",
                table: "UsersInfos",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UsersInfos_UserId",
                table: "UsersInfos");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfos_UserId",
                table: "UsersInfos",
                column: "UserId");
        }
    }
}
