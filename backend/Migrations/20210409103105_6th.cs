using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class _6th : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInfos",
                table: "UsersInfos");

            migrationBuilder.DropIndex(
                name: "IX_UsersInfos_UserId",
                table: "UsersInfos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UsersInfos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInfos",
                table: "UsersInfos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersInfos",
                table: "UsersInfos");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UsersInfos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersInfos",
                table: "UsersInfos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UsersInfos_UserId",
                table: "UsersInfos",
                column: "UserId",
                unique: true);
        }
    }
}
