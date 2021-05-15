using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CSEVD_UsersInfos_UserId1",
                table: "CSEVD");

            migrationBuilder.DropIndex(
                name: "IX_CSEVD_UserId1",
                table: "CSEVD");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "CSEVD");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CSEVD",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CSEVD_UserId",
                table: "CSEVD",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CSEVD_UsersInfos_UserId",
                table: "CSEVD",
                column: "UserId",
                principalTable: "UsersInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CSEVD_UsersInfos_UserId",
                table: "CSEVD");

            migrationBuilder.DropIndex(
                name: "IX_CSEVD_UserId",
                table: "CSEVD");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CSEVD");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "CSEVD",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CSEVD_UserId1",
                table: "CSEVD",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CSEVD_UsersInfos_UserId1",
                table: "CSEVD",
                column: "UserId1",
                principalTable: "UsersInfos",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
