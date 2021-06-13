using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fromUserId",
                table: "Warnings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QytetetQytetiId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ToUserId",
                table: "Emails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Qytetet",
                columns: table => new
                {
                    QytetiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QytetiName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qytetet", x => x.QytetiId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Warnings_fromUserId",
                table: "Warnings",
                column: "fromUserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Warnings_Users_fromUserId",
                table: "Warnings",
                column: "fromUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Qytetet_QytetetQytetiId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Warnings_Users_fromUserId",
                table: "Warnings");

            migrationBuilder.DropTable(
                name: "Qytetet");

            migrationBuilder.DropIndex(
                name: "IX_Warnings_fromUserId",
                table: "Warnings");

            migrationBuilder.DropIndex(
                name: "IX_Users_QytetetQytetiId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "fromUserId",
                table: "Warnings");

            migrationBuilder.DropColumn(
                name: "QytetetQytetiId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ToUserId",
                table: "Emails");
        }
    }
}
