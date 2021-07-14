using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class seadi6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Qytetet_QytetetQytetiId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_QytetetQytetiId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "QytetetQytetiId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "qytetiId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_qytetiId",
                table: "Users",
                column: "qytetiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Qytetet_qytetiId",
                table: "Users",
                column: "qytetiId",
                principalTable: "Qytetet",
                principalColumn: "QytetiId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Qytetet_qytetiId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_qytetiId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "qytetiId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "QytetetQytetiId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_QytetetQytetiId",
                table: "Users",
                column: "QytetetQytetiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Qytetet_QytetetQytetiId",
                table: "Users",
                column: "QytetetQytetiId",
                principalTable: "Qytetet",
                principalColumn: "QytetiId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
